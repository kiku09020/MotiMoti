using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class No : ButtonAbstract {
        CanvasManager canvas;
        PauseManager pause;

        void Start()
        {
            GameObject gmObj = GameObject.Find("GameManager");
            GameObject uiObj = gmObj.transform.Find("UIManager").gameObject;

            pause = gmObj.GetComponent<PauseManager>();
            canvas = uiObj.GetComponent<CanvasManager>();
        }

        public override void Clicked()
        {
            se.Play((int)SystemSound.AudioName.cancel);

            StartCoroutine(WaitCanvas());
        }

        IEnumerator WaitCanvas()
        {
            yield return new WaitForSecondsRealtime(0.15f);

            canvas.ActivateUncautionUI();         // キャンバス非表示
            pause.isRetry = false;
            pause.isExit = false;
        }
    }
}