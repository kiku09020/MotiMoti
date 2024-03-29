using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyData
{
    [Header("Parameters")]
    [SerializeField] string name;               // 名前
    [SerializeField] int motigomeCnt;           // もちごめのドロップ数]
    [SerializeField] int motigomeRandRange;     // もち米のランダム範囲

    public int MotigomeCnt => motigomeCnt;
    public int MotigomeRandRange => motigomeRandRange;
    public string Name => name;
}
