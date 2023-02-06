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
    [SerializeField] float switchDuration;      // 切り替え時間

    public bool IsOn { get; set; }     // 値

    float handlePosX;

    Sequence seq;

    private void Start()
    {
        handlePosX = Mathf.Abs(handle.anchoredPosition.x);
        UpdateToggle();
    }

    public void Switch()
    {
        SE.Instance.Play("btn_celect");

        IsOn = !IsOn;
        UpdateToggle();
    }

    void UpdateToggle()
    {
        var bgColor = IsOn ? onColor : offColor;
        var x = IsOn ? handlePosX : -handlePosX;

        seq?.Complete();
        seq = DOTween.Sequence();

        seq.Append(backImg.DOColor(bgColor, switchDuration))            // 色変更
            .Join(handle.DOAnchorPosX(x, switchDuration / 2));          // 移動

        seq.SetUpdate(true);// timeScale=0でも有効に
    }
}
