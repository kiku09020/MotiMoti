using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spines
{
    public interface IState : IStateBase
    {
        public SpinesController Spine{ get; set; }
    }
}