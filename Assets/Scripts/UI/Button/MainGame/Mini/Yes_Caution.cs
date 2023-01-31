using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class Yes_Caution : PauseButtons {

        public override void Clicked()
        {
            Time.timeScale = 1;                         // ���Ԓ�~�I��
            SE.Instance.Play("btn_celect");             // ���ʉ��Đ�
            CanvasManager.PauseUI.SetActive(false);     // �|�[�Y��ʔ�\��

            // ���g���C
            if (PauseManager.Instance.isRetry) {
                PauseManager.Instance.ResetFlags();                                                     // �l���Z�b�g
                SceneController.Instance.LoadNowSceneWithTransition(TransitionUI.Type.circleIn);        // �ēǂݍ���
            }

            // �Q�[���I��
            else if (PauseManager.Instance.isExit) {
                PauseManager.Instance.ResetFlags();                                                     // �l���Z�b�g
                SceneController.Instance.LoadSceneWithTransition("Title",TransitionUI.Type.circleIn);   // �^�C�g����
            }
        }
    }
}