using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FingerController : SimpleSingleton<FingerController>
{
    [Header("Duration")]
    [SerializeField] float animationDuration;       // アニメーションタイプ
    [SerializeField] float waitDuration;            // 次のループまでの待機時間

    [Header("Moving")]
    [SerializeField] float moveDistance;            // 移動量
    [SerializeField] Ease easeType;                 // イージングタイプ

//-------------------------------------------------------------------
    void Awake()
    {
        Animation(animationDuration, waitDuration, moveDistance, easeType);
    }

    //-------------------------------------------------------------------
    public void Animation(float animationDuration, float waitDuration, float moveDistance, Ease easeType = Ease.Unset)
    {
        DOTween.Sequence().Append(transform.DOMoveY(transform.position.y + moveDistance, animationDuration).SetDelay(waitDuration))        // 移動、待機
            .SetEase(easeType).SetLoops(-1, LoopType.Restart);      // ループ
    }

    // 削除
    public void Delete()
    {
        if (gameObject) {
            Destroy(gameObject);

        }
    }
}
