using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] new string name ;      // Enemy��(Inspector����w��)
    protected int motigomeCnt;              // �h���b�v��������Ă̐�

    GameObject target;
    public float TargetDist { get; private set; }                // Player�Ƃ̋���

//-------------------------------------------------------------------
    protected virtual void Awake()
    {
        SetDataParams(name);
        MotigomeDropper.SetParent();

        target = GameObject.Find("Moti");
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
        MotiParticle.Instance.Play("United", transform.position);
        SE.Instance.Play("attackEnemy");
        Destroy(this.gameObject);
    }

    protected void GetDist()
    {
        if (gameObject && target) {
            TargetDist = Vector2.Distance(target.transform.position, transform.position);
        }
    }
}
