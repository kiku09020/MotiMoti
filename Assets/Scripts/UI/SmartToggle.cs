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
    [SerializeField] bool onActive;             // �������
    [SerializeField] float switchDuration;      // �؂�ւ�����

    public bool Value { get; private set; }     // �l

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

        seq.Append(backImg.DOColor(bgColor, switchDuration))            // �F�ύX
            .Join(handle.DOAnchorPosX(x, switchDuration / 2));          // �ړ�

        seq.SetUpdate(true);// timeScale=0�ł��L����
    }
}
