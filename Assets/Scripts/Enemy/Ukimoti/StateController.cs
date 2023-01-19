using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ukimoti {
    public class StateController : StateControllerBase {
        public WaitingState Waiting { get; private set; }
        public MovingState Moving { get; private set; }

        public void Init()
        {
            Waiting = gameObject.AddComponent<WaitingState>();
            Moving = gameObject.AddComponent<MovingState>();
        }
    }
}