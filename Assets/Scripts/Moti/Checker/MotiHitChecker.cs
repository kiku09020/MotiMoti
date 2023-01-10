using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    [RequireComponent(typeof(Collider2D))]
    public class MotiHitChecker : HitCheckerTrigger
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

		protected override void HitEnter(Collider2D collision)
		{
            otherMoti = collision.gameObject.GetComponent<MotiController>();
            isMotiTrigger = true;
        }

		protected override void HitExit(Collider2D collision)
		{
            isMotiTrigger = false;
            otherMoti = null;
        }
	}
}