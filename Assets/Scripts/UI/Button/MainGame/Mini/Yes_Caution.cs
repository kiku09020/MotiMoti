using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class Yes_Caution : PauseButtons {

        SceneController scene;

        void Start()
        {
            scene = gmObj.GetComponent<SceneController>();
        }

        public override void Clicked()
        {
            Time.timeScale = 1;
            se.Play((int)SystemSound.AudioName.decision);

            // ���g���C
            if (pause.isRetry) {
                scene.LoadNowScene();           // �ēǂݍ���
            }

            // �Q�[���I��
            else if (pause.isExit) {
                scene.LoadScene("Title");       // �^�C�g����
            }
        }
    }
}