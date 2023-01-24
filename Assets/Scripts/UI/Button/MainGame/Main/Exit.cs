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
                PauseManager.Instance.isExit = true;
                PauseManager.Instance.SetCaution();
                CanvasManager.ActivateCautionUI(true);
            }

			else {
                SceneController.Instance.LoadPrevScene();
			}
        }
    }
}