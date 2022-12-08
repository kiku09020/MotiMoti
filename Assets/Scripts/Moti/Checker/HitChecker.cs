using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    [RequireComponent(typeof(Collider2D))]
    public class HitChecker : MonoBehaviour
    {
        /* 値 */
        bool isMotiTrigger;         // 範囲内に他のもちがいるか

        MotiController otherMoti;

        /* プロパティ */

        public bool IsMotiTrigger => isMotiTrigger;

        public MotiController OtherMoti => otherMoti;

        /* コンポーネント取得用 */
        MotiController moti;

        //-------------------------------------------------------------------
        private void Awake()
        {
            moti = transform.parent.GetComponent<MotiController>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            // 他のもち
            if (col.gameObject.tag == "Moti") {
                isMotiTrigger = true;
                otherMoti = col.gameObject.GetComponent<MotiController>();
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            // 他のもち
            if (col.gameObject.tag == "Moti") {
                isMotiTrigger = false;
            }
        }
    }
}