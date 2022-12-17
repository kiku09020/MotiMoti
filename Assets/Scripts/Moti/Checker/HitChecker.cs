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

        //-------------------------------------------------------------------
        private void OnTriggerEnter2D(Collider2D col)
        {
            // 他のもち
            if (col.gameObject.tag == "Moti") {
                otherMoti = col.gameObject.GetComponent<MotiController>();

                isMotiTrigger = true;
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            // 他のもち
            if (col.gameObject.tag == "Moti") {
                isMotiTrigger = false;
                otherMoti = null;
            }
        }

        // リセット
        public void InitValues()
        {
            isMotiTrigger = false;
            otherMoti = null;
        }
    }
}