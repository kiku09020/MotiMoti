using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingFire {
    public class StateController {

        public IState NowState { get; private set; }

		/* States */
		public WaitingState Waiting { get; }
		public MovingState Moving { get; }

        //-------------------------------------------------------------------
        public StateController(MovingFire fire)
		{
			Waiting = new WaitingState(fire);
			Moving = new MovingState(fire);
		}

        public void InitState(IState state)
		{
			NowState = state;
			NowState.StateEnter();
		}

        public void TransitionState(IState nextState)
		{
			NowState.StateExit();
			NowState = nextState;
			NowState.StateEnter();
		}

        public void StateUpdate()
		{
			NowState.StateUpdate();
		}
    }
}