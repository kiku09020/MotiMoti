using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti {
    public class FireHitChecker :HitCheckerTrigger
    {
        // Ξ
        MovingFire.MovingFire hitFire;      // Gκ½Ξ

        //-------------------------------------------------------------------
        public override void Init()
        {
            IsHit = false;
            hitFire = null;
        }

		protected override void HitEnter(Collider2D collision)
		{
            hitFire = collision.gameObject.GetComponent<MovingFire.MovingFire>();
        }

		protected override void HitExit(Collider2D collision)
		{
            hitFire = null;
        }

        // GoingσΤΕGκ½Μ
        public void GoingFire()
        {
            if (IsHit) {
                Destroy(hitFire.gameObject);
            }
        }

    }
}