using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyData
{
    [Header("Parameters")]
    [SerializeField] string name;               // ���O
    [SerializeField] int motigomeCnt;           // �������߂̃h���b�v��]
    [SerializeField] int motigomeRandRange;     // �����Ẵ����_���͈�

    public int MotigomeCnt => motigomeCnt;
    public int MotigomeRandRange => motigomeRandRange;
    public string Name => name;
}
