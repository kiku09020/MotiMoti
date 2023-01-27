using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] new string name ;              // Enemy名(Inspectorから指定)
    protected int motigomeCnt;                      // ドロップするもち米の数

    [SerializeField] float killedWaitTime = 0.1f;  // 倒されたときの待機時間

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
        TimeController.Instance.WaitSecond(killedWaitTime);     // 一時停止

        MotiGaugeManager.Instance.AddComboCount();                                                              // コンボ数追加
        MotigomeDropper.Drop(motigomeCnt * MotiGaugeManager.Instance.ComboCount, transform.position);           // もちごめのドロップ

        MotiParticle.Instance.Play("United", transform.position);                                               // パーティクル再生
        SE.Instance.Play("attackEnemy");                                                                        // 効果音再生

        Destroy(gameObject);                                                                                    // 削除
    } 
}
