using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class Continue :ButtonAbstract,IPause
    {
        /* コンポーネント取得用 */
        CanvasManager canvas;
        PauseManager pause;
        BGM bgm;

//-------------------------------------------------------------------
        void Start()
        {
            GameObject gmObj = GameObject.Find("GameManager").gameObject;
            GameObject uiObj = gmObj.transform.Find("UIManager").gameObject;
            GameObject audObj = gmObj.transform.Find("AudioManager").gameObject;

            pause = gmObj.GetComponent<PauseManager>();
            canvas = uiObj.GetComponent<CanvasManager>();
            bgm = audObj.GetComponent<BGM>();
        }

//-------------------------------------------------------------------
        public override void Clicked()
        {
            pause.IsPause = false;

            se.Play((int)SystemSound.AudioName.cancel);         // キャンセル音

            Time.timeScale = 1;                                 // 再開
            StartCoroutine(WaitCanvasActivate());               // 待機してから非表示
            bgm.Unpause();                                      // BGM再開
        }

        public IEnumerator WaitCanvasActivate()
        {
            yield return new WaitForSecondsRealtime(0.15f);
            canvas.Unpause();             // キャンバス表示
        }
    }
}