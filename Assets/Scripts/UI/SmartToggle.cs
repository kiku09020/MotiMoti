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
    [SerializeField] bool onActive;             // èâä˙èÛë‘
    [SerializeField] float switchDuration;      // êÿÇËë÷Ç¶éûä‘

    public bool Value { get; private set; }     // íl

    float handlePosX;

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

        var seq = DOTween.Sequence();
        seq.Append(backImg.DOColor(bgColor, switchDuration))            // êFïœçX
            .Join(handle.DOAnchorPosX(x, switchDuration / 2));          // à⁄ìÆ
    }
}
