using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spines {
    public class StateController : MonoBehaviour {
        GroundSpinesController spine;

        IState nowState;

        private void Awake()
        {
            spine = GetComponent<GroundSpinesController>();
        }

        public void InitState()
        {

        }

        public void StateUpdate()
        {

        }

        public void TransitionState()
        {

        }
    }
}