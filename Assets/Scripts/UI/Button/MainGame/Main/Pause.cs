using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class Pause : PauseButtons {

        /* �R���|�[�l���g�擾�p */
        BGM bgm;

//-------------------------------------------------------------------
        void Start()
        {
            GameObject audObj = gmObj.transform.Find("AudioManager").gameObject;

            bgm = audObj.GetComponent<BGM>();
        }

//-------------------------------------------------------------------
        public override void Clicked()
        {
            pause.IsPause = true;    // �؂�ւ�

            se.Play((int)SystemSound.AudioName.decision);       // ���艹

            Time.timeScale = 0;         // ��~

            bgm.Pause();                // BGM��~
            StartCoroutine(WaitCanvasActivate());
        }

        protected IEnumerator WaitCanvasActivate()
        {
            yield return new WaitForSecondsRealtime(0.15f);
            CanvasManager.ActivatePauseUI(true);             // �L�����o�X�\��
        }
    }
}
