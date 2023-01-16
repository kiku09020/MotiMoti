using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotiGaugeManager : Singleton<MotiGaugeManager>
{
    // �p���[
    static float nowPower;                              // ���݂̃p���[
    public static readonly int maxPower = 100;          // �p���[�ő�l


    // �R���{
    static int comboCount;                              // �R���{��
    [SerializeField] int maxComboCount = 10;            // �ő�R���{��
    static float comboTimer;                            // �^�C�}�[
    [SerializeField] float comboTimerLimit = 3;         // ��������


    /* �v���p�e�B */
    public static float NowPower => nowPower;
    public static int ComboCount => comboCount;

    // �t���O
    public static bool IsMaxGauge { get; private set; } // �Q�[�W���^����

//-------------------------------------------------------------------
    public static void Init()
	{
        nowPower = 0;
        comboCount = 0;
	}

//-------------------------------------------------------------------
    public void MotiGaugeUpdate()
    {
        // ���^���`�F�b�N
        IsMaxGauge = (nowPower >= maxPower) ? true : false;

        SubtractPower();        // ���炷
        ComboTimer();           // �R���{����
    }

    // �R���{�^�C�}�[
    void ComboTimer()
    {
        comboTimer += Time.deltaTime;

        // �������ԉ߂����Ƃ�
        if (comboTimer > comboTimerLimit) {
            comboTimer = 0;
            ResetComboCount();      // �R���{�����Z�b�g
        }
    }

    // �R���{�����Z
    public void AddComboCount()
	{
		if (comboCount < maxComboCount) {
            comboCount++;
		}

        comboTimer = 0;     // �R���{�^�C�}�[���Z�b�g

        MotiGaugeVisualizer.Instance.DispCombo();
	}

    // �R���{���̃��Z�b�g
    public static void ResetComboCount()
	{
        comboCount = 0;
	}

    // �p���[���Z
    public static void AddPower(float power)
	{
        // �R���{���ɉ����ĉ��Z
		if (nowPower < maxPower) {
            nowPower += power * (comboCount + 1);
		}

        // �ő�l�𒴂�����ő�l�ɂ���
		if (nowPower > maxPower) {
            nowPower = maxPower;
		}

        MotiGaugeVisualizer.Instance.SetDispPower();
    }

    // �p���[���Z
    public void SubtractPower()
    {
        if (MotiPowerUp.IsPowerUp) {
            if (nowPower > 0) {
                nowPower -= MotiPowerUp.Instance.timerValue;
            }

            if (nowPower < 0) {
                nowPower = 0;
            }
        }

        MotiGaugeVisualizer.Instance.SetDispPower();
    }
}
