using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// DotWeen�̓���
public class DotWeenTemplate : MonoBehaviour
{
    // �g��
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

    // ���Ƃ̃T�C�Y�ɖ߂�
    public static void ResizeScale_Undo(GameObject targetObj, float duration, float waitDuration, float targetScale, Ease easeType = Ease.Unset)
    {
        var scale = targetObj.transform.localScale;

        DOTween.Sequence()
            .Append(targetObj.transform.DOScale(targetScale, duration / 2))     // �ό`
            .AppendInterval(waitDuration)                                       // �ҋ@
            .Append(targetObj.transform.DOScale(scale, duration / 2))           // ���ɖ߂�

            .SetEase(easeType)
            .SetUpdate(true);
    }
}
