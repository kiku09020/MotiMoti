using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class Exit : PauseButtons {
        [SerializeField] bool cautionFlag;

        public override void Clicked()
        {
            SE.Instance.Play("btn_click");

            if (cautionFlag) {
                pause.isExit = true;
                pause.SetCaution();
                CanvasManager.ActivateCautionUI(true);
            }

			else {
                scene.LoadPrevScene();
			}
        }
    }
}