using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class Retry : PauseButtons {
        [SerializeField] bool cautionFlag;

        public override void Clicked()
        {
            SE.Instance.Play("btn_click");

            // ポーズ画面(警告)
            if (cautionFlag) {
                PauseManager.Instance.isRetry = true;
                PauseManager.Instance.SetCaution();
                CanvasManager.ActivateCautionUI(true);
            }

            // 通常
            else {
                SceneController.Instance.LoadNowSceneWithTransition(TransitionUI.Type.circleIn);        // シーン読み込み
            }
        }
    }
}