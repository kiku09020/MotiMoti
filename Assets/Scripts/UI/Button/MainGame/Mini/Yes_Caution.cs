using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class Yes_Caution : PauseButtons {

        public override void Clicked()
        {
            Time.timeScale = 1;
            SE.Instance.Play("btn_celect");
            var loadDuration = TransitionUI.Instance.TransitionDuration;

            TransitionUI.Instance.PlayTransition(TransitionUI.Type.circleIn);      // �J��
            CanvasManager.PauseUI.SetActive(false);                                 // UI��\��

            // ���g���C
            if (PauseManager.Instance.isRetry) {
                PauseManager.Instance.ResetFlags();                                 // �l���Z�b�g
                SceneController.Instance.LoadNowScene(loadDuration);                // �ēǂݍ���
            }

            // �Q�[���I��
            else if (PauseManager.Instance.isExit) {
                PauseManager.Instance.ResetFlags();                                 // �l���Z�b�g
                SceneController.Instance.LoadScene("Title", loadDuration);          // �^�C�g����
            }
        }
    }
}