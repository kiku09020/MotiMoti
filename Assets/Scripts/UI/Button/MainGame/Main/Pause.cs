using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class Pause : ButtonAbstract,IPause {
        /* コンポーネント取得用 */
        CanvasManager canvas;
        PauseManager pause;
        BGM bgm;

//-------------------------------------------------------------------
        void Start()
        {
            GameObject gmObj = GameObject.Find("GameManager").gameObject;
            GameObject audObj = gmObj.transform.Find("AudioManager").gameObject;
            GameObject uiObj = gmObj.transform.Find("UIManager").gameObject;

            pause = gmObj.GetComponent<PauseManager>();
            canvas = uiObj.GetComponent<CanvasManager>();
            bgm = audObj.GetComponent<BGM>();
        }

//-------------------------------------------------------------------
        public override void Clicked()
        {
            pause.IsPause = true;    // 切り替え

            // ポーズ時
            if (pause.IsPause) {
                se.Play((int)SystemSound.AudioName.decision);       // 決定音

                Time.timeScale = 0;         // 停止

                StartCoroutine(WaitCanvasActivate());
                bgm.Pause();                // BGM停止
            }
        }

        // キャンバスのSetActiveを効果音鳴るまで待機
        public IEnumerator WaitCanvasActivate()
        {
            yield return new WaitForSecondsRealtime(0.15f);
            canvas.Pause();             // キャンバス表示
        }
    }
}
