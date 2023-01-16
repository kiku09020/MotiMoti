using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yakimoti {
    public class StateController:StateControllerBase {

		/* States */
		public WaitingState Waiting { get; }
		public MovingState Moving { get; }

        //-------------------------------------------------------------------
        public StateController(Yakimoti fire)
		{
			Waiting = new WaitingState(fire);
			Moving = new MovingState(fire);
		}
    }
}