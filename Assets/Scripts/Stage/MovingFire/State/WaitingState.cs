using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingFire {
	public class WaitingState : IState {
		public MovingFire Fire { get; set; }

		public WaitingState(MovingFire fire)
		{
			Fire = fire;
		}

		public void StateEnter()
		{

		}

		public void StateUpdate()
		{
			Fire.WaitTimer();
		}

		public void StateExit()
		{

		}
	}
}