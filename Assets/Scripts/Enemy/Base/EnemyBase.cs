using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] new string name ;      // Enemy名(Inspectorから指定)
    protected int motigomeCnt;              // ドロップするもち米の数

    GameObject target;
    public float TargetDist { get; private set; }                // Playerとの距離

//-------------------------------------------------------------------
    protected virtual void Awake()
    {
        SetDataParams(name);
        MotigomeDropper.SetParent();

        target = GameObject.Find("Moti");
    }

//-------------------------------------------------------------------
    // 指定した名前からデータ取得して、値をセット
    void SetDataParams(string name)
	{
        var data = EnemyData_SO.ReadData(name);

        motigomeCnt = MotigomeDropper.SetMotigomeCnt(data.MotigomeCnt, data.MotigomeRandRange);
	}

    // やられるときの処理
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
