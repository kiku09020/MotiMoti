using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spines {
    public class StateController : StateControllerBase {
        SpinesController spine;

		public AttackingState Attacking { get; private set; }
		public WaitingState Waiting { get; private set; }

		private void Awake()
		{
			spine = GetComponent<SpinesController>();

			Attacking = gameObject.AddComponent<AttackingState>();
			Waiting = gameObject.AddComponent<WaitingState>();
		}
	}
}