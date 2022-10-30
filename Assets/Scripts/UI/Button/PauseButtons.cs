using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
	public abstract class PauseButtons : Buttons {
		protected GameObject gmObj;
		protected CanvasManager canvas;
		protected PauseManager pause;

		public abstract void Clicked();

		protected override void Awake()
		{
			gmObj = GameObject.Find("GameManager");
			GameObject uiObj = gmObj.transform.Find("UIManager").gameObject;

			SESet(gmObj);

			canvas = uiObj.GetComponent<CanvasManager>();
			pause = gmObj.GetComponent<PauseManager>();
		}
	}
}