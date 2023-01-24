using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spines
{
    public class WaitingState : SpineState
    {
        public override void StateEnter()
        {

        }

        public override void StateUpdate()
        {
            Spine.IsActive = false;
            Spine.Wait();
        }

        public override void StateExit()
        {

        }
    }
}