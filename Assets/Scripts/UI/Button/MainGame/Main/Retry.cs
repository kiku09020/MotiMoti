using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class Retry : PauseButtons {
        [SerializeField] bool cautionFlag;

        public override void Clicked()
        {
            se.Play((int)SystemSound.AudioName.click);

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