using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Motigome {
    public class MovingState : IState {
        public Motigome Motigome { get; set; }

        public MovingState(Motigome motigome)
        {
            Motigome = motigome;
        }

        public void StateEnter()
        {
            Motigome.Moving.MoveStart();
        }

        public void StateUpdate()
        {
            Motigome.Moving.MoveUpdate();
        }

        public void StateExit()
        {

        }
    }
}