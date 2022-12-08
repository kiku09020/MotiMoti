using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Moti
{
    /* もちを合体させる処理 */
    public class MotiUniter : MonoBehaviour
    {
        /* 値 */
        [SerializeField] float fixingTime;                  // ステージにくっつくまでの時間

        bool isUnitable;        // 合体可能か

        /* プロパティ */
        public bool IsUnitable => isUnitable;

        /* コンポーネント取得用 */
        MotiController moti;


        //-------------------------------------------------------------------
        void Awake()
        {
            /* オブジェクト取得 */


            /* コンポーネント取得 */
            moti = GetComponent<MotiController>();

            /* 初期化 */

        }

        //-------------------------------------------------------------------
        public void Unite()
        {
            var other = moti.MotiHit.OtherMoti;

            var flag = moti.Family.CheckIfChild(other);

            transform.localScale += other.transform.localScale;                         // 大きさ変更
            moti.Line.StretchableLenth += other.Line.StretchableLenth;

            // 触れていたら、そこに移動
            if (other.Ground.IsGround) {
                var targetPos = (other.transform.position + (Vector3)other.Ground.HitPoint) / 2;
                transform.DOMove(targetPos, fixingTime);
            }

            // 演出
            moti.Particle.Play(ParticleNames_Moti.united, transform.position);
            moti.Audio.Play(MotiAudioNames.united);

            Destroy(other.gameObject);                                                  // 削除
        }

        // 合体可能かを調べる
        public void CheckUnitable()
        {
            HitChecker hit = moti.MotiHit;

            if (hit.IsMotiTrigger) {     // 近くに他のもちがいるとき
                isUnitable = true;
            }

            else {
                isUnitable = false;
            }
        }
    }
}