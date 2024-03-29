using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName =fileName,menuName ="ScriptableObjects/Enemy")]
public class EnemyData_SO : ScriptableObject
{
    const string fileName = "Enemy";

    [SerializeField] List<EnemyData> enemyList = new List<EnemyData>();

    public List<EnemyData> EnemyList => enemyList;

//-------------------------------------------------------------------
    // データ読み込み
    public static EnemyData ReadData(string name)
	{
        var enemyDataSO = Resources.Load(fileName) as EnemyData_SO;
        var enemyData = enemyDataSO.enemyList.Find(data => data.Name == name);      // 呼び出し元の名前とデータ名が同じものを検索
        return enemyData;
	}
}
