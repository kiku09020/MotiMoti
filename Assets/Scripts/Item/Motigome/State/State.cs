using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Motigome {
    public abstract class State:StateBase {
        public Motigome Motigome { get; protected set; }

        private void Awake()
        {
            Motigome = GetComponent<Motigome>();
        }
    }
}