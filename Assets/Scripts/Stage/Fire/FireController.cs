using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FireController : SimpleSingleton<FireController>
{
    [Header("Start")]
    [SerializeField] int startMovableDist;  // ������悤�ɂȂ鋗��

    [Header("Always")]
    [SerializeField] float speed;           // �ړ����x
    [SerializeField] float speedUpValue;    // ���x�㏸�l

    [Header("United")]
    [SerializeField] float moveTime;        // �ړ�����
    [SerializeField] float minDist;         // �����Ƃ̍Œ዗��

    public bool isEnable;                   // �L��

//-------------------------------------------------------------------
    void Awake()
    {
        
    }

    void FixedUpdate()
    {
        SetStartMovable();

		if (isEnable) {
            MoveUp();
		}
    }

    // �L���E�����̐؂�ւ�
    public void SetEnable()
    {
        isEnable = !isEnable;
    }

    public void SetEnable(bool enable)
    {
        isEnable = enable;
    }

//-------------------------------------------------------------------
    // United���̈ړ�
    public void UnitedMove(Moti.MotiController targetMoti)
    {
        var motiPosY = targetMoti.transform.position.y;
        var dist = Mathf.Abs(DistanceCaluculator.CheckAxisLength(transform.position.y, motiPosY));

        var unitedPosY = motiPosY;      // ���݂̈ʒu��ۑ�

        // �ړ�
        if (minDist < dist) {
            var targetPosY = unitedPosY - minDist;
            transform.DOMoveY(targetPosY, moveTime);
        }
    }

    // ��̕��Ɉړ�
    void MoveUp()
	{
        transform.position += new Vector3(0, speed, 0);
	}

    // ���x�㏸
    public void SpeedUp()
	{
        speed += speedUpValue;
	}

    // �w��̍����ȏ�ŉ΂��L���ɂȂ�
    void SetStartMovable()
    {
        // �w�荂���𒴂����瓮��
        if (startMovableDist < MotiDistanceManager.Distance) {
            isEnable = true;
        }
    }
}
