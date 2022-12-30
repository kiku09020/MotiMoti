using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class StartBtn : TitleButtons {

		public override void Clicked()
        {
            se.Play((int)SystemSound.AudioName.decision);
            SceneController.Instance.LoadNextScene();
        }
    }
}
