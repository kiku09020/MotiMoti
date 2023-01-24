using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spines
{
    public class AttackingState : SpineState
    {
        public override void StateEnter()
        {
            Spine.Attacking.Attack();
		}

        public override void StateUpdate()
        {
            Spine.IsActive = true;

            Spine.Attacking.AttackWait();
		}

        public override void StateExit()
        {

		}
    }
}