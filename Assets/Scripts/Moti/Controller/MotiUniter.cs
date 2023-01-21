using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    /* もちを合体させる処理 */
    public class MotiUniter : MonoBehaviour
    {
        /* 値 */
        [SerializeField] float fixingTime;                  // ステージにくっつくまでの時間

        /* コンポーネント取得用 */
        MotiController moti;


        //-------------------------------------------------------------------
        void Awake()
        {
            /* コンポーネント取得 */
            moti = GetComponent<MotiController>();
        }

        //-------------------------------------------------------------------
        public void Unite()
        {
            var other = moti.MotiHit.OtherMoti;
            transform.localScale *= 2;

            // 演出
            MotiParticle.Instance.Play("United", transform.position);
            SE.Instance.Play("united");

            Destroy(other.gameObject);                                                  // 削除
            moti.Family.RemoveChild();
        }
    }
}