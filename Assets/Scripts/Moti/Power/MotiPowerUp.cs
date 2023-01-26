using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MotiPowerUp : SimpleSingleton<MotiPowerUp> {
    [SerializeField] Moti.MotiController targetMoti;

    [Header("Time")]
    [SerializeField] float powerUpWaitTime; // �p���[�A�b�v���̑ҋ@����
    [SerializeField] float powerUpTime;     // �p���[�A�b�v����
    float timer;

    [Header("UI")]
    [SerializeField] Text powerupText;      // �p���[�A�b�v�e�L�X�g
    [SerializeField] Transform canvas;      // �����p�L�����o�X
    [SerializeField] float textDispTime;    // �e�L�X�g�̕\������
    [SerializeField] Ease easeType;         // �e�L�X�g�̃C�[�W���O
    [SerializeField] float moveDist;        // �e�L�X�g�̈ړ�����

    bool powerUpOnce;
    bool isStretchPowerUp;                  // �L�тĂ�Ƃ��Ƀp���[�A�b�v�����t���O
    bool isStretchPowerDown;                // �L�тĂ���Ƃ��Ƀp���[�_�E������  

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

        CheckPowerUped();
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

    // �p���[�A�b�v���̏���
    void PowerUp()
    {
        var motiPos = targetMoti.transform.position;
        var targetPos = motiPos + new Vector3(0, moveDist);

        // �e�L�X�g�\��
        TextGenerater.GenerateText(powerupText, motiPos, canvas.transform, targetPos, textDispTime, easeType);

        TimeController.Instance.WaitSecond(powerUpWaitTime);

        // �L�тĂ��Ȃ�������A�T�C�Y�ύX
        if (!targetMoti.Stretcher.IsStretching) {
            targetMoti.Line.StretchableLenth *= 2;
        }

        else {
            isStretchPowerUp = true;
        }
    }

    // �p���[�_�E����
    void PowerDown()
    {
        // �L�тĂ��Ȃ�������A���̃T�C�Y�ɖ߂�
        if (!targetMoti.Stretcher.IsStretching) {
            targetMoti.Line.StretchableLenth /= 2;
        }

        else {
            isStretchPowerDown = true;
        }

        isStretchPowerUp = false;
    }

    // �L�тĂ����ԂŃp���[�A�b�v�����Ƃ��̏���
    void CheckPowerUped()
    {
        // �p���[�A�b�v��
        if (IsPowerUp && isStretchPowerUp) {
            // �L�т�
            if (!targetMoti.Stretcher.IsStretching) {
                isStretchPowerUp = false;
                targetMoti.Line.StretchableLenth *= 2;
            }
        }

        // �k��
        if (isStretchPowerDown) {
            if (!targetMoti.Stretcher.IsStretching) {
                isStretchPowerDown = false;
                targetMoti.Line.StretchableLenth /= 2;
            }
        }
    }
}