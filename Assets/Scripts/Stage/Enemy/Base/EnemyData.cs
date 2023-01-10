using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyData
{
    [Header("Parameters")]
    [SerializeField] string name;           // 名前
    [SerializeField] int motigomeCnt;       // もちごめのドロップ数

    [Header("Audio")]
    [SerializeField] List<AudioClip> clipList = new List<AudioClip>();


    public int MotigomeCnt => motigomeCnt;
    public string Name => name;
    public List<AudioClip> ClipList => clipList;

//-------------------------------------------------------------------

}
