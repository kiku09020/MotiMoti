using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class Yes_Caution : PauseButtons {

        public override void Clicked()
        {
            Time.timeScale = 1;
            SE.Instance.Play("btn_celect");

            // ���g���C
            if (PauseManager.Instance.isRetry) {
                PauseManager.Instance.ResetFlags();
                SceneController.Instance.LoadNowScene();           // �ēǂݍ���
            }

            // �Q�[���I��
            else if (PauseManager.Instance.isExit) {
                PauseManager.Instance.ResetFlags();
                SceneController.Instance.LoadScene("Title");       // �^�C�g����
            }
        }
    }
}