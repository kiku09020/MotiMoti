using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class No_Caution : PauseButtons {

        public override void Clicked()
        {
            SE.Instance.Play("btn_cancel");

            StartCoroutine(WaitCanvas());
        }

        IEnumerator WaitCanvas()
        {
            yield return new WaitForSecondsRealtime(0.15f);

            CanvasManager.ActivateCautionUI(false);         // キャンバス非表示
            pause.isRetry = false;
            pause.isExit = false;
        }
    }
}