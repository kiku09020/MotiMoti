using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class Exit : PauseButtons {
        [SerializeField] bool cautionFlag;

        public override void Clicked()
        {
            se.Play((int)SystemSound.AudioName.click);

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