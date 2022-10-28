using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class Retry : ButtonAbstract {
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
            se.Play((int)SystemSound.AudioName.click);
            pause.isRetry = true;
            pause.SetCaution();
            canvas.Caution();
        }
    }
}