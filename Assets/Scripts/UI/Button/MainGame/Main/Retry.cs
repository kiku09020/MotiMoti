using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class Retry : PauseButtons {
        [SerializeField] bool cautionFlag;

        public override void Clicked()
        {
            SE.Instance.Play("btn_click");

            // �|�[�Y���(�x��)
            if (cautionFlag) {
                PauseManager.Instance.isRetry = true;
                PauseManager.Instance.SetCaution();
                CanvasManager.ActivateCautionUI(true);
            }

            // �ʏ�
            else {
                SceneController.Instance.LoadNowSceneWithTransition(TransitionUI.Type.circleIn);        // �V�[���ǂݍ���
            }
        }
    }
}