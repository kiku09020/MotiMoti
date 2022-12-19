using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    [RequireComponent(typeof(Collider2D))]
    public class GroundChecker : MonoBehaviour
    {
        /* 値 */
        bool isGround;              // 着地しているか

        Vector2 hitPoint;           // 触れたところの位置
        Vector2 hitVector;          // 触れた瞬間のオブジェクトとのベクトル

        /* プロパティ */
        public bool IsGround => isGround;
        public Vector2 HitPoint => hitPoint;
        public Vector2 HitVector => hitVector;

        public bool ColEnabled => col.enabled;      // colliderのenabled

        /* コンポーネント取得用 */
        [SerializeField] Collider2D col;
        [SerializeField] MotiAudioController aud;

        // 有効化・無効化
        public void SetEnable(bool enable)
        {
            col.enabled = enable;
        }

        // もちが触れたオブジェクトの方向を調べる
        void CheckHitDirection(GameObject otherObject)
        {
            var ownPos = transform.position;
            var otherPos = otherObject.transform.position;

            hitVector = otherPos - ownPos;
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            // 着地時
            if (col.gameObject.tag == "Stage") {

                // 触れた点を取得
                foreach (ContactPoint2D contact in col.contacts) {
                    hitPoint = contact.point;
                }

                isGround = true;                        // 着地状態にする
                CheckHitDirection(col.gameObject);      // 方向取得
                aud.Play(MotiAudioNames.hitGround);   // 着地音再生
            }
        }

        void OnCollisionExit2D(Collision2D col)
        {
            // 離れるとき
            if (col.gameObject.tag == "Stage") {
                isGround = false;
            }
        }
    }
}