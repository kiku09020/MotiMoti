using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class Retry : PauseButtons {
        [SerializeField] bool cautionFlag;

        public override void Clicked()
        {
            SE.Instance.Play("btn_click");

            if (cautionFlag) {
                pause.isRetry = true;
                pause.SetCaution();
                CanvasManager.ActivateCautionUI(true);
            }

			else {
                scene.LoadNowScene();
			}
        }
    }
}