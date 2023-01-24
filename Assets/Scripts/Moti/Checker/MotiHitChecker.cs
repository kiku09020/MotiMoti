using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    [RequireComponent(typeof(Collider2D))]
    public class MotiHitChecker : HitCheckerTrigger
    {
        // もち
        MotiController otherMoti;

        /* プロパティ */
        public MotiController OtherMoti => otherMoti;

        //-------------------------------------------------------------------
        // リセット
        protected override void Awake()
        {
            base.Awake();

            otherMoti = null;
        }

        protected override void HitEnter(Collider2D collision)
		{
            otherMoti = collision.gameObject.GetComponent<MotiController>();
        }

		protected override void HitExit(Collider2D collision)
		{
            otherMoti = null;
        }
	}
}