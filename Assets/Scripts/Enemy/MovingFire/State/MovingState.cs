using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingFire {
	public class MovingState : IState {
		public MovingFire Fire { get; set; }

		public MovingState(MovingFire fire)
		{
			Fire = fire;
		}

		public void StateEnter()
		{
			Fire.SetTarget();
			Fire.SetMoveTime();
			Fire.Move();
		}

		public void StateUpdate()
		{

		}

		public void StateExit()
		{

		}
	}
}