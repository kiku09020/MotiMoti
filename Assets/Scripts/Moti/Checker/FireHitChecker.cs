using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti {
    public class FireHitChecker :HitCheckerBase
    {
        // 火
        bool isHitFire;                 // 触れたか
        MovingFire.MovingFire hitFire;      // 触れた火

        /* プロパティ */
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

        // Going状態で触れた時の処理
        public void GoingFire()
        {
            if (isHitFire) {
                Destroy(hitFire.gameObject);
            }
        }

    }
}