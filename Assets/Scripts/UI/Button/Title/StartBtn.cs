using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class StartBtn : Buttons {

		public override void Clicked()
        {
            SE.Instance.Play("btn_celect");                                                     // 効果音再生
            SceneController.Instance.LoadNextSceneWithTransition(TransitionUI.Type.circleIn);   // ロード
        }
    }
}
