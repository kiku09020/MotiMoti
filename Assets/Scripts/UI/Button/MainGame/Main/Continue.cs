using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class Continue :PauseButtons {

        /* コンポーネント取得用 */
        BGM bgm;

        void Start()
        {
            GameObject audObj = gmObj.transform.Find("AudioManager").gameObject;

            bgm = audObj.GetComponent<BGM>();
        }

        public override void Clicked()
        {
            pause.IsPause = false;

            se.Play((int)SystemSound.AudioName.cancel);         // キャンセル音

            Time.timeScale = 1;                                 // 再開
            StartCoroutine(WaitCanvasActivate());               // 待機してから非表示
            bgm.Unpause();                                      // BGM再開
        }

        protected IEnumerator WaitCanvasActivate()
        {
            yield return new WaitForSecondsRealtime(0.15f);
            canvas.ActivateUnpauseUI();             // キャンバス表示
        }
    }
}