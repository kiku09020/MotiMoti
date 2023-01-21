using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class Pause : PauseButtons {

//-------------------------------------------------------------------
        public override void Clicked()
        {
            pause.IsPause = true;    // �؂�ւ�

            SE.Instance.Play("btn_celect");

            Time.timeScale = 0;         // ��~

            BGM.Instance.Pause();
            StartCoroutine(WaitCanvasActivate());
        }

        protected IEnumerator WaitCanvasActivate()
        {
            yield return new WaitForSecondsRealtime(0.15f);
            CanvasManager.ActivatePauseUI(true);             // �L�����o�X�\��
        }
    }
}
