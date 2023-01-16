using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spines {
    public class StateController : StateControllerBase {
        SpinesController spine;

		private void Awake()
		{
			spine = GetComponent<SpinesController>();
		}
	}
}