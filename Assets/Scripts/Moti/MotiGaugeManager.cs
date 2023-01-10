using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotiGaugeManager : MonoBehaviour
{
    static float nowPower;                              // ���݂̃p���[
    static int comboCount;                              // �R���{��
    public static readonly int maxPower = 100;          // �p���[�ő�l
    public static readonly int maxComboCount = 10;      // �ő�R���{��

    static public float NowPower => nowPower;
    static public int ComboCount => comboCount;

//-------------------------------------------------------------------
    public static void Init()
	{
        nowPower = 0;
        comboCount = 0;
	}

//-------------------------------------------------------------------
    // �R���{�����Z
    public static void AddComboCount()
	{
		if (comboCount < maxComboCount) {
            comboCount++;
		}
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
	}
}
