using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yakimoti {
    public class StateController:StateControllerBase {

		/* States */
		public WaitingState Waiting { get; private set; }
		public MovingState Moving { get; private set; }

        //-------------------------------------------------------------------
        private void Awake()
        {
            Waiting = gameObject.AddComponent<WaitingState>();
            Moving = gameObject.AddComponent<MovingState>();
        }
    }
}