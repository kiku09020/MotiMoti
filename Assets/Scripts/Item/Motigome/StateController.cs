using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Motigome {
    public class StateController:StateControllerBase  {

        public DroppedState Drop { get; private set; }
        public MovingState  Moving { get; private set; }

        void Awake()
        {
            Drop = gameObject.AddComponent<DroppedState>();
            Moving = gameObject.AddComponent<MovingState>();
        }
    }
}