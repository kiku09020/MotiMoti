using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Motigome {
    public class MovingState : State {
        public override void StateEnter()
        {
            Motigome.Moving.MoveStart();
        }

        public override void StateUpdate()
        {
            Motigome.Moving.MoveUpdate();
        }

        public override void StateExit()
        {

        }
    }
}