using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotiGaugeManager : MonoBehaviour
{
    // �p���[
    static float nowPower;                              // ���݂̃p���[
    public static readonly int maxPower = 100;          // �p���[�ő�l


    // �R���{
    static int comboCount;                              // �R���{��
    public static readonly int maxComboCount = 10;      // �ő�R���{��
    static float comboTimer;                            // �^�C�}�[
    static readonly float comboTimerLimit = 3;          // ��������


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
    public static void MotiGaugeUpdate()
    {
        // ���^���`�F�b�N
        IsMaxGauge = (nowPower >= maxPower) ? true : false;

        ComboTimer();
    }

    // �R���{�^�C�}�[
    static void ComboTimer()
    {
        comboTimer += Time.deltaTime;

        // �������ԉ߂����Ƃ�
        if (comboTimer > comboTimerLimit) {
            comboTimer = 0;
            ResetComboCount();      // �R���{�����Z�b�g
        }
    }

    // �R���{�����Z
    public static void AddComboCount()
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
}
