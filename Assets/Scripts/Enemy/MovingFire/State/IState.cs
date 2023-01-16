using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yakimoti {
	public interface IState  {
		public Yakimoti Fire { get; set; }

		public void StateEnter();
		public void StateUpdate();
		public void StateExit();
	}
}