using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti {
    public class FireHitChecker :HitCheckerTrigger
    {
        // ‰Î
        MovingFire.MovingFire hitFire;      // G‚ê‚½‰Î

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

        // Goingó‘Ô‚ÅG‚ê‚½‚Ìˆ—
        public void GoingFire()
        {
            if (IsHit) {
                Destroy(hitFire.gameObject);
            }
        }

    }
}