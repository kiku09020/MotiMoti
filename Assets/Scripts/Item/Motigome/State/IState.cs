using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Motigome {
    public interface IState {
        public void StateEnter();
        public void StateUpdate();
        public void StateExit();

        public Motigome Motigome { get; set; }
    }
}