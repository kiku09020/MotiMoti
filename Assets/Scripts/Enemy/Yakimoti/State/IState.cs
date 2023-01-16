using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yakimoti {
	public interface IState:IStateBase  {
		public Yakimoti Fire { get; set; }
	}
}