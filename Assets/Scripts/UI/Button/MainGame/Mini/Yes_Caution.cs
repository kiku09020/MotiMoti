using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class Yes_Caution : PauseButtons {

        public override void Clicked()
        {
            Time.timeScale = 1;
            se.Play((int)SystemSound.AudioName.decision);

            // リトライ
            if (pause.isRetry) {
                pause.ResetFlags();
                scene.LoadNowScene();           // 再読み込み
            }

            // ゲーム終了
            else if (pause.isExit) {
                pause.ResetFlags();
                scene.LoadScene("Title");       // タイトルへ
            }
        }
    }
}