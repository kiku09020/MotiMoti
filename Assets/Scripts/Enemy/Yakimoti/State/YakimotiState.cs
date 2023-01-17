using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yakimoti {
	public abstract class YakimotiState:StateBase  {
		public Yakimoti Yakimoti { get; set; }

        private void Awake()
        {
            Yakimoti = GetComponent<Yakimoti>();
        }
    }
}