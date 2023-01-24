using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MotiPowerUp : SimpleSingleton<MotiPowerUp> {
    [SerializeField] Moti.MotiController targetMoti;

 
    [SerializeField] float powerUpTime;     // �p���[�A�b�v����
    float timer;

    [Header("UI")]
    [SerializeField] Text powerupText;      // �p���[�A�b�v�e�L�X�g
    [SerializeField] Transform canvas;      // �����p�L�����o�X
    [SerializeField] float textDispTime;    // �e�L�X�g�̕\������

    bool powerUpOnce;

    public static bool IsPowerUp { get; private set; }       // �p���[�A�b�v��
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

    // �p���[�A�b�v�����̃`�F�b�N
    void CheckPower()
    {
        // �Q�[�WMAX�ɂȂ�����p���[�A�b�v
        if (MotiGaugeManager.IsMaxGauge) {
            if (!powerUpOnce) {
                PowerUp();

                powerUpOnce = true;
            }

            timer = 0;
            IsPowerUp = true;
        }
    }

    // �^�C�}�[
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
        var motiPos = targetMoti.transform.position;

        TextGenerater.GenerateText(powerupText, motiPos, canvas.transform, motiPos + new Vector3(0, 1), textDispTime);
        targetMoti.Line.StretchableLenth *= 2;
    }

    void PowerDown()
    {
        targetMoti.Line.StretchableLenth /= 2;
    }
}