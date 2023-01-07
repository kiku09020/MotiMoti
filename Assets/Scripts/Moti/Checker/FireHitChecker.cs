using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti {
    public class FireHitChecker :HitCheckerBase
    {
        // âŒ
        bool isHitFire;                 // êGÇÍÇΩÇ©
        MovingFire.MovingFire hitFire;      // êGÇÍÇΩâŒ

        /* ÉvÉçÉpÉeÉB */
        public bool IsHitFire => isHitFire;
        public MovingFire.MovingFire HitFire => hitFire;

        //-------------------------------------------------------------------
        public override void Init()
        {
            isHitFire = false;
            hitFire = null;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == targetTagName) {
                isHitFire = true;
                hitFire = collision.gameObject.GetComponent<MovingFire.MovingFire>();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == targetTagName) {
                isHitFire = false;
                hitFire = null;
            }
        }

        // GoingèÛë‘Ç≈êGÇÍÇΩéûÇÃèàóù
        public void GoingFire()
        {
            if (isHitFire) {
                Destroy(hitFire.gameObject);
            }
        }

    }
}