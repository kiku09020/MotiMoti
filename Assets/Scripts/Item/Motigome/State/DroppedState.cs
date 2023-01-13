using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Motigome {
    public class DroppedState : MonoBehaviour, IState {
        public Motigome Motigome { get; set; }

        public DroppedState(Motigome motigome)
        {
            Motigome = motigome;
        }

        public void StateEnter()
        {
            Motigome.DropMoving();
        }

        public void StateUpdate()
        {

        }

        public void StateExit()
        {

        }
    }
}