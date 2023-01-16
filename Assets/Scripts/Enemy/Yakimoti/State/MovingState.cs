using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yakimoti {
	public class MovingState : IState {
		public Yakimoti Fire { get; set; }

		public MovingState(Yakimoti fire)
		{
			Fire = fire;
		}

		public void StateEnter()
		{
			Fire.SetTarget();
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