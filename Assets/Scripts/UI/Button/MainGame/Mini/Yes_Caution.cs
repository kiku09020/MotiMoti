using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class Yes_Caution : PauseButtons {

        public override void Clicked()
        {
            Time.timeScale = 1;                         // 時間停止終了
            SE.Instance.Play("btn_celect");             // 効果音再生
            CanvasManager.PauseUI.SetActive(false);     // ポーズ画面非表示

            // リトライ
            if (PauseManager.Instance.isRetry) {
                PauseManager.Instance.ResetFlags();                                                     // 値リセット
                SceneController.Instance.LoadNowSceneWithTransition(TransitionUI.Type.circleIn);        // 再読み込み
            }

            // ゲーム終了
            else if (PauseManager.Instance.isExit) {
                PauseManager.Instance.ResetFlags();                                                     // 値リセット
                SceneController.Instance.LoadSceneWithTransition("Title",TransitionUI.Type.circleIn);   // タイトルへ
            }
        }
    }
}