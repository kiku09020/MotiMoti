using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public abstract class TitleButtons : Buttons {

		protected GameObject titleObj;

		public abstract void Clicked();

		void Awake()
		{
			titleObj = GameObject.Find("TitleManager");
		}
	}
}