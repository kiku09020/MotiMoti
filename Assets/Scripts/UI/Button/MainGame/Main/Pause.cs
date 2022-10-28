using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class Pause : ButtonAbstract,IPause {
        /* �R���|�[�l���g�擾�p */
        CanvasManager canvas;
        PauseManager pause;
        BGM bgm;

//-------------------------------------------------------------------
        void Start()
        {
            GameObject gmObj = GameObject.Find("GameManager").gameObject;
            GameObject audObj = gmObj.transform.Find("AudioManager").gameObject;
            GameObject uiObj = gmObj.transform.Find("UIManager").gameObject;

            pause = gmObj.GetComponent<PauseManager>();
            canvas = uiObj.GetComponent<CanvasManager>();
            bgm = audObj.GetComponent<BGM>();
        }

//-------------------------------------------------------------------
        public override void Clicked()
        {
            pause.IsPause = true;    // �؂�ւ�

            // �|�[�Y��
            if (pause.IsPause) {
                se.Play((int)SystemSound.AudioName.decision);       // ���艹

                Time.timeScale = 0;         // ��~

                StartCoroutine(WaitCanvasActivate());
                bgm.Pause();                // BGM��~
            }
        }

        // �L�����o�X��SetActive�����ʉ���܂őҋ@
        public IEnumerator WaitCanvasActivate()
        {
            yield return new WaitForSecondsRealtime(0.15f);
            canvas.Pause();             // �L�����o�X�\��
        }
    }
}
