using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FingerController : MonoBehaviour
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

    }

}
