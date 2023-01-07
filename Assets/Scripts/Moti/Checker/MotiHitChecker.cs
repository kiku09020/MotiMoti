using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    [RequireComponent(typeof(Collider2D))]
    public class MotiHitChecker : HitCheckerBase
    {
        // もち
        bool isMotiTrigger;         // 範囲内に他のもちがいるか
        MotiController otherMoti;

        /* プロパティ */
        public bool IsMotiTrigger => isMotiTrigger;
        public MotiController OtherMoti => otherMoti;

        //-------------------------------------------------------------------
        // リセット
        public override void Init()
        {
            isMotiTrigger = false;
            otherMoti = null;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == targetTagName) {
                otherMoti = col.gameObject.GetComponent<MotiController>();
                isMotiTrigger = true;
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.tag == targetTagName) {
                isMotiTrigger = false;
                otherMoti = null;
            }
        }

    }
}