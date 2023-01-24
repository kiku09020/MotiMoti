using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextGenerater : MonoBehaviour
{
    /// <summary>
    /// 通常生成
    /// </summary>
    public static void GenerateText(Text text, Vector2 position, Transform parent, float destTime = 1)
    {
        var genedObj = Instantiate(text, position, Quaternion.identity, parent);    　// 生成

        Destroy(genedObj, destTime);        // 削除
    }

    /// <summary>
    /// 生成後に移動
    /// </summary>
    public static void GenerateText(Text text, Vector2 position, Transform parent,
                                Vector2 targetPosition, float moveDuration = 1, Ease moveEase = Ease.Unset, float destroyDuration = 0.25f)
    {
        var genedObj = Instantiate(text, position, Quaternion.identity, parent);    // 生成

        DOTween.Sequence()
            .Append(genedObj.transform.DOMove(targetPosition, moveDuration).SetEase(moveEase))      // 移動
            .Append(genedObj.transform.DOScale(Vector2.zero, destroyDuration))                      // 移動後小さく
            .OnComplete(() => Destroy(genedObj));                                                   // 削除
    }

    /// <summary>
    /// 移動しながら拡大縮小
    /// </summary>
    public static void GenerateText(Text text, Vector2 position, Transform parent,
                                Vector2 targetPosition, Vector2 targetScale, float moveDuration = 1, Ease moveEase = Ease.Unset)
    {
        var genedObj = Instantiate(text, position, Quaternion.identity, parent);    // 生成

        DOTween.Sequence()
            .Append(genedObj.transform.DOMove(targetPosition, moveDuration))        // 移動
            .Join(genedObj.transform.DOScale(targetScale, moveDuration))            // 拡大
            .OnComplete(() => Destroy(genedObj));                                   // 削除
    }
}
