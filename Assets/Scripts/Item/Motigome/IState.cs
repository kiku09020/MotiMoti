using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Motigome {
    public interface IState :IStateBase{
        public Motigome Motigome { get; set; }
    }
}