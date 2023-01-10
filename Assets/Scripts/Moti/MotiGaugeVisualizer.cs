using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MotiGaugeVisualizer : Singleton<MotiGaugeVisualizer>
{
    [Header("Easing")]
    [SerializeField] float easeTime;        // �C�[�W���O����
    [SerializeField] Ease easeType;         // �C�[�W���O�^�C�v

    [Header("UI")]
    [SerializeField] Image powerImage;      // �摜

    static float dispPower;         // �\��
    static float targetPower;       // �ڕW

//-------------------------------------------------------------------
    void Awake()
    {
        MotiGaugeManager.Init();

        dispPower = 0;
        targetPower = 0;
    }

    void FixedUpdate()
    {
        DispPower();
    }

//-------------------------------------------------------------------
    // �\���p���[�̃Z�b�g(�p���[���Z���ɌĂяo��)
    public void SetDispPower()
	{
        SetTargetPower();

        DOVirtual.Float(dispPower, targetPower, easeTime, value=>{
            dispPower = value;
        }).SetEase(easeType);

	}

    // �ڕW�p���[�̃Z�b�g
    void SetTargetPower()
	{
        targetPower = MotiGaugeManager.NowPower / 100f;
	}

    // �p���[�̕\��
    void DispPower()
	{
        powerImage.fillAmount = dispPower;
	}
}
