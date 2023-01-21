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
            if (pause.isRetry) {
                pause.ResetFlags();
                scene.LoadNowScene();           // �ēǂݍ���
            }

            // �Q�[���I��
            else if (pause.isExit) {
                pause.ResetFlags();
                scene.LoadScene("Title");       // �^�C�g����
            }
        }
    }
}