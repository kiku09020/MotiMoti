using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yakimoti {
	public class WaitingState : YakimotiState {

		public override void StateEnter()
		{

		}

		public override void StateUpdate()
		{
			Yakimoti.WaitTimer();
		}

		public override void StateExit()
		{

		}
	}
}