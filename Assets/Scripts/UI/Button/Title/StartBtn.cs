using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class StartBtn : TitleButtons {

        SceneController scene;

		private void Start()
		{
            scene = titleObj.GetComponent<SceneController>();
        }

		public override void Clicked()
        {
            se.Play((int)SystemSound.AudioName.decision);
            scene.LoadNextScene();
        }
    }
}
