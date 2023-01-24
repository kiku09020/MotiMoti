using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spines
{
    public abstract class SpineState : StateBase
    {
        public SpinesController Spine{ get; private set; }

        void Awake()
        {
            Spine = GetComponent<SpinesController>();
        }
    }
}