using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] new string name;       // Enemy��(Inspector����w��)
    protected int motigomeCnt;              // �h���b�v��������Ă̐�

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
        MotigomeDropper.Drop(motigomeCnt, transform.position);
        Destroy(this.gameObject);
    } 
}
