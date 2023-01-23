using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class Yes_Caution : PauseButtons {

        public override void Clicked()
        {
            Time.timeScale = 1;
            SE.Instance.Play("btn_celect");

            // リトライ
            if (PauseManager.Instance.isRetry) {
                PauseManager.Instance.ResetFlags();
                SceneController.Instance.LoadNowScene();           // 再読み込み
            }

            // ゲーム終了
            else if (PauseManager.Instance.isExit) {
                PauseManager.Instance.ResetFlags();
                SceneController.Instance.LoadScene("Title");       // タイトルへ
            }
        }
    }
}