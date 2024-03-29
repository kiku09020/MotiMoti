using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MotiPowerUp : SimpleSingleton<MotiPowerUp> {
    [SerializeField] Moti.MotiController targetMoti;

    [Header("Time")]
    [SerializeField] float powerUpWaitTime; // パワーアップ時の待機時間
    [SerializeField] float powerUpTime;     // パワーアップ時間
    float timer;

    [Header("UI")]
    [SerializeField] Text powerupText;      // パワーアップテキスト
    [SerializeField] Transform canvas;      // 生成用キャンバス
    [SerializeField] float textDispTime;    // テキストの表示時間
    [SerializeField] Ease easeType;         // テキストのイージング
    [SerializeField] float moveDist;        // テキストの移動距離

    bool powerUpOnce;
    bool isStretchPowerUp;                  // 伸びてるときにパワーアップしたフラグ
    bool isStretchPowerDown;                // 伸びているときにパワーダウンした  

    GameObject partObj;

    public static bool IsPowerUp { get; private set; }       // パワーアップ中
    public float PowerUpTime => powerUpTime;

    //-------------------------------------------------------------------
    public void Init()
    {
        IsPowerUp = false;
	}

    public void PowerUpdate()
    {
        CheckPower();
        SetTimer();

        CheckPowerUped();
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
        }
    }

    // パワーアップ時の処理
    void PowerUp()
    {
        var motiPos = targetMoti.transform.position;
        var targetPos = motiPos + new Vector3(0, moveDist);

        // テキスト表示
        TextGenerater.GenerateText(powerupText, motiPos, canvas.transform, targetPos, textDispTime, easeType);

        // 待機
        TimeController.Instance.WaitSecond(powerUpWaitTime);
        partObj = MotiParticle.Instance.Play("PowerUp", motiPos, targetMoti.transform);         // パーティクル再生
        BGM.Instance.ChangePitch(1.2f);

        DotWeenTemplate.ResizeScale_Undo(targetMoti.gameObject, 0.5f, 0, 0.75f);                // もち変形

        // 伸びていなかったら、サイズ変更
        if (!targetMoti.Stretcher.IsStretching) {
            targetMoti.Line.StretchableLenth *= 2;
        }

        else {
            isStretchPowerUp = true;
        }
    }

    // パワーダウン時
    void PowerDown()
    {
        // 伸びていなかったら、元のサイズに戻す
        if (!targetMoti.Stretcher.IsStretching) {
            targetMoti.Line.StretchableLenth /= 2;
        }

        else {
            isStretchPowerDown = true;
        }

        isStretchPowerUp = false;
        BGM.Instance.ChangePitch(1);
        Destroy(partObj);           // パーティクル削除
    }

    // 伸びている状態でパワーアップしたときの処理
    void CheckPowerUped()
    {
        // パワーアップ中
        if (IsPowerUp && isStretchPowerUp) {
            // 伸びる
            if (!targetMoti.Stretcher.IsStretching) {
                isStretchPowerUp = false;
                targetMoti.Line.StretchableLenth *= 2;
            }
        }

        // 縮む
        if (isStretchPowerDown) {
            if (!targetMoti.Stretcher.IsStretching) {
                isStretchPowerDown = false;
                targetMoti.Line.StretchableLenth /= 2;
            }
        }
    }
}