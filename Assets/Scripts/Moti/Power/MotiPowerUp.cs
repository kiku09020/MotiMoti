using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MotiPowerUp : SimpleSingleton<MotiPowerUp> {
    [SerializeField] Moti.MotiController targetMoti;

    [SerializeField] float powerUpTime;     // パワーアップ時間
    float timer;

    bool powerUpOnce;

    public static bool IsPowerUp { get; private set; }       // パワーアップ中
    public float timerValue { get; private set; }            // timer/timerLimit

    //-------------------------------------------------------------------
    public void Init()
    {
        IsPowerUp = false;
	}

    public void PowerUpdate()
    {
        CheckPower();
        SetTimer();
    }

    // パワーアップ中かのチェック
    void CheckPower()
    {
        // ゲージMAXになったらパワーアップ
        if (MotiGaugeManager.IsMaxGauge) {
            if (!powerUpOnce) {
                PowerUp();

                powerUpOnce = true;
            }

            timer = 0;
            IsPowerUp = true;
        }
    }

    // タイマー
    void SetTimer()
    {
        if (IsPowerUp) {
            timer += Time.deltaTime;

            if (timer > powerUpTime) {
                PowerDown();

                timer = 0;
                IsPowerUp = false;
                powerUpOnce = false;
            }

            timerValue = timer / powerUpTime;
        }
    }

    void PowerUp()
    {
        targetMoti.Line.StretchableLenth *= 2;
    }

    void PowerDown()
    {
        targetMoti.Line.StretchableLenth /= 2;
    }
}