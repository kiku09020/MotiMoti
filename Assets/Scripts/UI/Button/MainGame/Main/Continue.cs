using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class Continue :PauseButtons {

        public override void Clicked()
        {
            pause.IsPause = false;

            SE.Instance.Play("btn_cancel");

            Time.timeScale = 1;                                 // 再開
            StartCoroutine(WaitCanvasActivate());               // 待機してから非表示
            BGM.Instance.UnPause();
        }

        protected IEnumerator WaitCanvasActivate()
        {
            yield return new WaitForSecondsRealtime(0.15f);
            CanvasManager.ActivatePauseUI(false);             // キャンバス表示
        }
    }
}