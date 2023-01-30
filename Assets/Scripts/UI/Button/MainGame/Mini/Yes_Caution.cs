using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class Yes_Caution : PauseButtons {

        public override void Clicked()
        {
            Time.timeScale = 1;
            SE.Instance.Play("btn_celect");
            var loadDuration = TransitionUI.Instance.TransitionDuration;

            TransitionUI.Instance.PlayTransition(TransitionUI.Type.circleIn);      // 遷移
            CanvasManager.PauseUI.SetActive(false);                                 // UI非表示

            // リトライ
            if (PauseManager.Instance.isRetry) {
                PauseManager.Instance.ResetFlags();                                 // 値リセット
                SceneController.Instance.LoadNowScene(loadDuration);                // 再読み込み
            }

            // ゲーム終了
            else if (PauseManager.Instance.isExit) {
                PauseManager.Instance.ResetFlags();                                 // 値リセット
                SceneController.Instance.LoadScene("Title", loadDuration);          // タイトルへ
            }
        }
    }
}