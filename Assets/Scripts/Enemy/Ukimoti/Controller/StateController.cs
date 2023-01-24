using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ukimoti {
    public class StateController : StateControllerBase {
        public IdleState Idle { get; private set; }
        public MovingState Moving { get; private set; }

        public void Init()
        {
            Idle = gameObject.AddComponent<IdleState>();
            Moving = gameObject.AddComponent<MovingState>();
        }
    }
}