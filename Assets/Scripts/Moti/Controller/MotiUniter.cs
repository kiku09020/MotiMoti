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

        /* プロパティ */

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

            transform.localScale += other.transform.localScale;                         // 大きさ変更

            // 演出
            moti.Particle.Play(ParticleNames_Moti.united, transform.position);
            moti.Audio.Play(MotiAudioNames.united);

            Destroy(other.gameObject);                                                  // 削除
            moti.Family.RemoveChild();
        }
    }
}