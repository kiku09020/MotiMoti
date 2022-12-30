using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
	public abstract class PauseButtons : Buttons {
		protected GameObject gmObj;
		protected PauseManager pause;
		protected SceneController scene;

		public abstract void Clicked();

		protected override void Awake()
		{
			gmObj = GameObject.Find("GameManager");
			SESet(gmObj);

			pause = PauseManager.Instance;
			scene = SceneController.Instance;
		}
	}
}