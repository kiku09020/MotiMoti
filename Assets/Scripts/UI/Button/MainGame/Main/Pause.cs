using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class Pause : PauseButtons {

        /* コンポーネント取得用 */
        BGM bgm;

//-------------------------------------------------------------------
        void Start()
        {
            GameObject audObj = gmObj.transform.Find("AudioManager").gameObject;

            bgm = audObj.GetComponent<BGM>();
        }

//-------------------------------------------------------------------
        public override void Clicked()
        {
            pause.IsPause = true;    // 切り替え

            se.Play((int)SystemSound.AudioName.decision);       // 決定音

            Time.timeScale = 0;         // 停止

            bgm.Pause();                // BGM停止
            StartCoroutine(WaitCanvasActivate());
        }

        protected IEnumerator WaitCanvasActivate()
        {
            yield return new WaitForSecondsRealtime(0.15f);
            CanvasManager.ActivatePauseUI(true);             // キャンバス表示
        }
    }
}
