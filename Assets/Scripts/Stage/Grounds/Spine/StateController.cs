using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spines {
    public class StateController : StateControllerBase {
		public AttackingState Attacking { get; private set; }
		public WaitingState Waiting { get; private set; }

		public void Init()
        {
			Attacking = gameObject.AddComponent<AttackingState>();
			Waiting = gameObject.AddComponent<WaitingState>();
		}
	}
}