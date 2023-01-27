using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MotiGaugeVisualizer : SimpleSingleton<MotiGaugeVisualizer>
{
    [Header("Easing")]
    [SerializeField] float easeTime;        // �C�[�W���O����
    [SerializeField] Ease easeType;         // �C�[�W���O�^�C�v

    [Header("UI")]
    [SerializeField] Image powerImage;      // �Q�[�W�摜
    [SerializeField] Text comboText;        // �R���{�e�L�X�g

    float dispPower;         // �\��

//-------------------------------------------------------------------
    void Awake()
    {
        MotiGaugeManager.Instance.Init();
        MotiPowerUp.Instance.Init();

        dispPower = 0;
    }

    void FixedUpdate()
    {
        if (!GameManager.isResult) {
            MotiGaugeManager.Instance.MotiGaugeUpdate();
            MotiPowerUp.Instance.PowerUpdate();
            DispPower();
            DispCombo();
        }
    }

//-------------------------------------------------------------------
    // �\���p���[�̃Z�b�g(�p���[���Z���ɌĂяo��)
    public void SetDispPower()
	{
        dispPower = MotiGaugeManager.Instance.NowPower / 100;
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