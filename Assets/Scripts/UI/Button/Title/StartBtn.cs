using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class StartBtn : Buttons {

		public override void Clicked()
        {
            SE.Instance.Play("btn_celect");                                                     // å¯â âπçƒê∂
            SceneController.Instance.LoadNextSceneWithTransition(TransitionUI.Type.circleIn);   // ÉçÅ[Éh
        }
    }
}
