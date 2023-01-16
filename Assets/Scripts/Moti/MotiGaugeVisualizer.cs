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
    [SerializeField] Image powerImage;      // �Q�[�W�摜
    [SerializeField] Text comboText;        // �R���{�e�L�X�g

    float dispPower;         // �\��
    float targetPower;       // �ڕW

//-------------------------------------------------------------------
    void Awake()
    {
        MotiGaugeManager.Instance.Init();

        dispPower = 0;
        targetPower = 0;
    }

    void FixedUpdate()
    {
        MotiGaugeManager.Instance.MotiGaugeUpdate();
        MotiPowerUp.Instance.PowerUpdate();
        DispPower();
        DispCombo();
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
        targetPower = MotiGaugeManager.Instance.NowPower / 100f;
	}

    // �\���R���{�Z�b�g(�R���{���Z��)
    public void DispCombo()
    {
        if (MotiGaugeManager.Instance.ComboCount > 1) {
            comboText.text = $"�~{MotiGaugeManager.Instance.ComboCount}";
        }
        else {
            comboText.text = "";
        }
    }

    // �p���[�̕\��
    void DispPower()
	{
        powerImage.fillAmount = dispPower;
	}
}
