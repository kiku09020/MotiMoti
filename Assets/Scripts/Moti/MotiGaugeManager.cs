using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotiGaugeManager : MonoBehaviour
{
    static float nowPower;                              // 現在のパワー
    static int comboCount;                              // コンボ数
    public static readonly int maxPower = 100;          // パワー最大値
    public static readonly int maxComboCount = 10;      // 最大コンボ数

    static public float NowPower => nowPower;
    static public int ComboCount => comboCount;

//-------------------------------------------------------------------
    public static void Init()
	{
        nowPower = 0;
        comboCount = 0;
	}

//-------------------------------------------------------------------
    // コンボ数加算
    public static void AddComboCount()
	{
		if (comboCount < maxComboCount) {
            comboCount++;
		}
	}

    // コンボ数のリセット
    public static void ResetComboCount()
	{
        comboCount = 0;
	}

    // パワー加算
    public static void AddPower(float power)
	{
        // コンボ数に応じて加算
		if (nowPower < maxPower) {
            nowPower += power * (comboCount + 1);
		}

        // 最大値を超えたら最大値にする
		if (nowPower > maxPower) {
            nowPower = maxPower;
		}
	}
}
