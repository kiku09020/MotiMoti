using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class StartBtn : Buttons {

		public override void Clicked()
        {
            SE.Instance.Play("btn_celect");                                                     // ���ʉ��Đ�
            SceneController.Instance.LoadNextSceneWithTransition(TransitionUI.Type.circleIn);   // ���[�h
        }
    }
}
