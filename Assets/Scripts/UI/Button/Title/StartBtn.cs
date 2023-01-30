using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class StartBtn : Buttons {

		public override void Clicked()
        {
            SE.Instance.Play("btn_celect");                                         // 効果音再生
            TransitionUI.Instance.PlayTransition(TransitionUI.Type.circleIn);       // 画面遷移開始

            var transDuration = TransitionUI.Instance.TransitionDuration;           // 遷移時間取得
            SceneController.Instance.LoadNextScene(transDuration);                  // ロード
        }
    }
}
