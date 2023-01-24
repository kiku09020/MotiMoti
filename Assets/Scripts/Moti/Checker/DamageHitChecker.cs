using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti {
    public class DamageHitChecker : HitCheckerTrigger {
        protected override void HitEnter(Collider2D collision)
        {
            GameManager.isResult = true;
        }

        protected override void HitExit(Collider2D collision)
        {
            
        }
    }
}