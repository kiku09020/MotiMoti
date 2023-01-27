using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// DotWeenの動き
public class DotWeenTemplate : MonoBehaviour
{
    // 拡大
    public static void ResizeScale(GameObject targetObj, float duration, Vector2 targetScale, Ease easeType = Ease.Unset)
    {
        targetObj.transform.DOScale(targetScale, duration)
            .SetEase(easeType)
            .SetUpdate(true);
    }

    public static void ResizeScale(GameObject targetObj, float duration, float targetScale, Ease easeType = Ease.Unset)
    {
        targetObj.transform.DOScale(targetScale, duration)
            .SetEase(easeType)
            .SetUpdate(true);
    }

    // もとのサイズに戻す
    public static void ResizeScale_Undo(GameObject targetObj, float duration, float waitDuration, float targetScale, Ease easeType = Ease.Unset)
    {
        var scale = targetObj.transform.localScale;

        DOTween.Sequence()
            .Append(targetObj.transform.DOScale(targetScale, duration / 2))     // 変形
            .AppendInterval(waitDuration)                                       // 待機
            .Append(targetObj.transform.DOScale(scale, duration / 2))           // 元に戻す

            .SetEase(easeType)
            .SetUpdate(true);
    }
}
