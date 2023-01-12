using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] new string name;       // Enemy名(Inspectorから指定)
    protected int motigomeCnt;              // ドロップするもち米の数

//-------------------------------------------------------------------
    protected virtual void Awake()
    {
        SetDataParams(name);
        MotigomeDropper.SetParent();
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
        MotigomeDropper.Drop(motigomeCnt, transform.position);
        Destroy(this.gameObject);
    } 
}
