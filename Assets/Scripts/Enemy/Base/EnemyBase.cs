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
        StartCoroutine(TimeStopCoruoutine());
    } 

    IEnumerator TimeStopCoruoutine()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.1f);
        Time.timeScale = 1;

        MotiGaugeManager.Instance.AddComboCount();
        MotigomeDropper.Drop(motigomeCnt * MotiGaugeManager.Instance.ComboCount, transform.position);
        Destroy(this.gameObject);
    }
}
