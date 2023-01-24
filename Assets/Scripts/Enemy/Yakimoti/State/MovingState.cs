using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yakimoti {
	public class MovingState : YakimotiState {

		public override void StateEnter()
		{
			Yakimoti.SetTarget();
			Yakimoti.Move();
		}

		public override void StateUpdate()
		{

		}

		public override void StateExit()
		{

		}
	}
}