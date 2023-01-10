using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MovingFire {
	public interface IState  {
		public MovingFire Fire { get; set; }

		public void StateEnter();
		public void StateUpdate();
		public void StateExit();
	}
}