using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Motigome {
    public class StateController : StateControllerBase {

        public IdlingState Idle{ get; }
        public MovingState Moving { get; }

        public StateController(Motigome motigome)
        {
            Idle = new IdlingState(motigome);
            Moving = new MovingState(motigome);
        }

        //-------------------------------------------------------------------
    }
}