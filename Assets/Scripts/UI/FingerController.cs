using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FingerController : MonoBehaviour
{
    [Header("Duration")]
    [SerializeField] float animationDuration;       // �A�j���[�V�����^�C�v
    [SerializeField] float waitDuration;            // ���̃��[�v�܂ł̑ҋ@����

    [Header("Moving")]
    [SerializeField] float moveDistance;            // �ړ���
    [SerializeField] Ease easeType;                 // �C�[�W���O�^�C�v

//-------------------------------------------------------------------
    void Awake()
    {
        Animation(animationDuration, waitDuration, moveDistance, easeType);
    }

    //-------------------------------------------------------------------
    public void Animation(float animationDuration, float waitDuration, float moveDistance, Ease easeType = Ease.Unset)
    {

    }

}
