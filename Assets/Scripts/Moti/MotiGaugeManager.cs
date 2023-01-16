using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotiGaugeManager : Singleton<MotiGaugeManager>
{
    // パワー
    float nowPower;                                 // 現在のパワー
    const int maxPower = 100;                       // パワー最大値


    // コンボ
    int comboCount;                                 // コンボ数
    [SerializeField] int maxComboCount = 10;        // 最大コンボ数
    float comboTimer;                               // タイマー
    [SerializeField] float comboTimerLimit = 3;     // 制限時間


    /* プロパティ */
    public float NowPower => nowPower;
    public int ComboCount => comboCount;

    // フラグ
    public static bool IsMaxGauge { get; private set; } // ゲージ満タンか

//-------------------------------------------------------------------
    public void Init()
	{
        nowPower = 0;
        comboCount = 0;

        IsMaxGauge = false;
	}

//-------------------------------------------------------------------
    public void MotiGaugeUpdate()
    {
        // 満タンチェック
        IsMaxGauge = (nowPower >= maxPower) ? true : false;

        SubtractPower();        // 減らす
        ComboTimer();           // コンボ時間
    }

    // コンボタイマー
    void ComboTimer()
    {
        comboTimer += Time.deltaTime;

        // 制限時間過ぎたとき
        if (comboTimer > comboTimerLimit) {
            comboTimer = 0;
            ResetComboCount();      // コンボ数リセット
        }
    }

    // コンボ数加算
    public void AddComboCount()
	{
		if (comboCount < maxComboCount) {
            comboCount++;
		}

        comboTimer = 0;     // コンボタイマーリセット

        MotiGaugeVisualizer.Instance.DispCombo();
	}

    // コンボ数のリセット
    public void ResetComboCount()
	{
        comboCount = 0;
	}

    // パワー加算
    public void AddPower(float power)
	{
        // コンボ数に応じて加算
		if (nowPower < maxPower) {
            nowPower += power * (comboCount + 1);
		}

        // 最大値を超えたら最大値にする
		if (nowPower > maxPower) {
            nowPower = maxPower;
		}

        MotiGaugeVisualizer.Instance.SetDispPower();
    }

    // パワー減算
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

    // 最大にする(Debug用)
    public void SetPowerMax()
    {
        nowPower = maxPower;
    }
}
