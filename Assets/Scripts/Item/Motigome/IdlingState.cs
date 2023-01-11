using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Motigome {
    public class IdlingState : IState {
        public Motigome Motigome { get; set; }

        public IdlingState(Motigome motigome)
        {
            Motigome = motigome;
        }

        public void StateEnter()
        {

        }

        public void StateUpdate()
        {

        }

        public void StateExit()
        {

        }
    }
}