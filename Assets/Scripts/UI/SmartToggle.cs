using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SmartToggle : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] Image backImg;
    [SerializeField] RectTransform handle;


    [Header("Color")]
    [SerializeField] Color offColor;
    [SerializeField] Color onColor;

    [Header("Other")]
    [SerializeField] bool onActive;             // 初期状態
    [SerializeField] float switchDuration;      // 切り替え時間

    public bool Value { get; private set; }     // 値

    float handlePosX;

    Sequence seq;

    private void Awake()
    {
        handlePosX = Mathf.Abs(handle.anchoredPosition.x);
        Value = onActive;
        UpdateToggle();
    }

    public void Switch()
    {
        Value = !Value;
        UpdateToggle();
    }

    void UpdateToggle()
    {
        var bgColor = Value ? onColor : offColor;
        var x = Value ? handlePosX : -handlePosX;

        seq?.Complete();
        seq = DOTween.Sequence();

        seq.Append(backImg.DOColor(bgColor, switchDuration))            // 色変更
            .Join(handle.DOAnchorPosX(x, switchDuration / 2));          // 移動

        seq.SetUpdate(true);// timeScale=0でも有効に
    }
}
