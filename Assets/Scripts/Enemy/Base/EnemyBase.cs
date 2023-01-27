using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] new string name ;              // Enemy��(Inspector����w��)
    protected int motigomeCnt;                      // �h���b�v��������Ă̐�

    [SerializeField] float killedWaitTime = 0.1f;  // �|���ꂽ�Ƃ��̑ҋ@����

//-------------------------------------------------------------------
    protected virtual void Awake()
    {
        SetDataParams(name);
        MotigomeDropper.SetParent();
    }

//-------------------------------------------------------------------
    // �w�肵�����O����f�[�^�擾���āA�l���Z�b�g
    void SetDataParams(string name)
	{
        var data = EnemyData_SO.ReadData(name);

        motigomeCnt = MotigomeDropper.SetMotigomeCnt(data.MotigomeCnt, data.MotigomeRandRange);
	}

    // �����Ƃ��̏���
    public virtual void Killed()
    {
        TimeController.Instance.WaitSecond(killedWaitTime);     // �ꎞ��~

        MotiGaugeManager.Instance.AddComboCount();                                                              // �R���{���ǉ�
        MotigomeDropper.Drop(motigomeCnt * MotiGaugeManager.Instance.ComboCount, transform.position);           // �������߂̃h���b�v

        MotiParticle.Instance.Play("United", transform.position);                                               // �p�[�e�B�N���Đ�
        SE.Instance.Play("attackEnemy");                                                                        // ���ʉ��Đ�

        Destroy(gameObject);                                                                                    // �폜
    } 
}
