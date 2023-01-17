using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Motigome {
    public class DroppedState : State {
        public override void StateEnter()
        {
            Motigome.DropMoving();
        }

        public override void StateUpdate()
        {

        }

        public override void StateExit()
        {

        }
    }
}