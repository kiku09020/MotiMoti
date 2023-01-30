using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class StartBtn : Buttons {

		public override void Clicked()
        {
            SE.Instance.Play("btn_celect");                                         // ���ʉ��Đ�
            TransitionUI.Instance.PlayTransition(TransitionUI.Type.circleIn);       // ��ʑJ�ڊJ�n

            var transDuration = TransitionUI.Instance.TransitionDuration;           // �J�ڎ��Ԏ擾
            SceneController.Instance.LoadNextScene(transDuration);                  // ���[�h
        }
    }
}
