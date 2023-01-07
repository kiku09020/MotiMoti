using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    [RequireComponent(typeof(Collider2D))]
    public class GroundHitChecker : HitCheckerBase {
        /* 値 */
        bool isGround;              // 着地しているか

        Vector2 hitPoint;           // 触れたところの位置
        Vector2 hitVector;          // 触れた瞬間のオブジェクトとのベクトル

        float hitAngle;             // 基準ベクトル(transform.right)からhitVectorの間の角度

        public enum HitDirection {
            up,
            left,
            down,
            right
        }

        HitDirection hitDir;        // 4方向

        /* プロパティ */
        public bool IsGround => isGround;
        public Vector2 HitPoint => hitPoint;
        public Vector2 HitVector => hitVector;

        public HitDirection HitDir => hitDir;

        public bool ColEnabled { get => col.enabled; set => col.enabled = value; }      // colliderのenabled

        /* コンポーネント取得用 */
        [SerializeField] Collider2D col;

        //-------------------------------------------------------------------
        public override void Init()
        {
            hitPoint = moti.Family.OtherMoti.transform.position;
            hitVector = Vector2.zero;
            hitAngle = 0;

            col.enabled = true;
            moti.RB.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        // 有効化・無効化
        public void SetCollisionEnable(bool enable)
        {
            col.enabled = enable;
        }

        // もちが触れたオブジェクトの方向を調べる
        void GetHitDirection()
        {
            Vector2 ownPos = moti.transform.position;

            hitVector = (hitPoint - ownPos).normalized;         // hitPoint - moti

            // 基準ベクトルからhitVectorまでの角度
            hitAngle = Vector2.Angle(transform.right, hitVector);

            var cross = transform.right.x * hitVector.y - transform.right.y * hitVector.x;      // 外積(基準ベクトルからhitVectorの上下判定)
            if (cross == -1) {
                hitAngle += 180;        // 基準ベクトルよりも下にあれば、角度に180度足して360度を再現
            }

            print(hitAngle);
        }

        // 接地方向を四方向に変換
        void SetGroundDirection()
        {
            const float startAngle = 45;        // 始点
            const float rangeAngle = 90;        // 一方向当たりの範囲の角度

            for (int i = 0; i < 4; i++) {
                var minAngle = startAngle + rangeAngle * i;
                var maxAngle = minAngle + rangeAngle;

                // min < angle < max
                if (minAngle <= hitAngle && hitAngle < maxAngle) {
                    hitDir = (HitDirection)i;       // 指定の角度内に入ってたらその方向を指定
                    break;
                }

                // 右(改良したい)
                else if (   (0 <= hitAngle   && hitAngle < startAngle) ||
                            (315 <= hitAngle && hitAngle < 360)) {
                    hitDir = HitDirection.right;
                    break;
                }
            }

            print(hitDir);
        }

        //-------------------------------------------------------------------
         void OnCollisionEnter2D(Collision2D col)
        {
            // 着地時
            if (col.gameObject.tag == targetTagName) {
                // 触れた点を取得
                foreach (ContactPoint2D contact in col.contacts) {
                    hitPoint = contact.point;
                }

                isGround = true;            // 着地状態にする
                GetHitDirection();          // 方向取得
                SetGroundDirection();       // 4方向

                moti.RB.constraints = RigidbodyConstraints2D.FreezeAll;     // 位置固定

                /* 演出 */
                moti.Particle.Play(ParticleNames_Moti.ground, moti.Ground.HitPoint);
                moti.Audio.Play(MotiAudioNames.hitGround);   // 着地音再生
            }
        }

        void OnCollisionExit2D(Collision2D col)
        {
            // 離れるとき
            if (col.gameObject.tag == targetTagName) {
                isGround = false;

                moti.RB.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
}