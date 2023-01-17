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
            Spine.Wait();
        }

        public override void StateExit()
        {

        }
    }
}