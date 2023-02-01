using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Button {
    public class StartBtn : Buttons {

        [Header("Animation")]
        [SerializeField] float animDuration;
        [SerializeField] float targetScale;
        [SerializeField] Ease easeType;


        private void Awake()
        {
            transform.DOScale(targetScale, animDuration)
                .SetEase(easeType)
                
                .SetLoops(-1, LoopType.Restart);
        }

        public override void Clicked()
        {
            SE.Instance.Play("btn_celect");                                                     // å¯â âπçƒê∂
            SceneController.Instance.LoadNextSceneWithTransition(TransitionUI.Type.circleIn);   // ÉçÅ[Éh
        }
    }
}
