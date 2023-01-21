using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class StartBtn : TitleButtons {

		public override void Clicked()
        {
            SE.Instance.Play("btn_celect");
            SceneController.Instance.LoadNextScene();
        }
    }
}
