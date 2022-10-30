using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public abstract class MainButtons : Buttons{

		protected GameObject gmObj;

		protected override void Awake()
		{
			gmObj = GameObject.Find("GameManager");

			SESet(gmObj);
		}

		public abstract void Clicked();
	}
}