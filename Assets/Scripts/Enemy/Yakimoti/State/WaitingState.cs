using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yakimoti {
	public class WaitingState : IState {
		public Yakimoti Fire { get; set; }

		public WaitingState(Yakimoti fire)
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