using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class Yes : ButtonAbstract {
        SceneController scene;
        PauseManager pause;

        void Start()
        {
            GameObject gmObj = GameObject.Find("GameManager");

            scene = gmObj.GetComponent<SceneController>();
            pause = gmObj.GetComponent<PauseManager>();
        }

        public override void Clicked()
        {
            Time.timeScale = 1;
            se.Play((int)SystemSound.AudioName.decision);

            // リトライ
            if (pause.isRetry) {
                scene.LoadNowScene();           // 再読み込み
            }

            // ゲーム終了
            else if (pause.isExit) {
                scene.LoadScene("Title");       // タイトルへ
            }
        }
    }
}