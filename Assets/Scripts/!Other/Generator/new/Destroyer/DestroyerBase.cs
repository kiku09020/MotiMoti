using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public abstract class DestroyerBase : MonoBehaviour {
    public enum DestroyType {
        maxCount,       // 最大数基準
        distance,       // 距離基準
    }

    [SerializeField] public DestroyType type;

    [SerializeField] public float destroyDistance;
    [SerializeField] public int destroyMaxCnt;

    [SerializeField] public GenerateTargetChecker checker;

    // コンポーネント

    //-------------------------------------------------------------------
    private void LateUpdate()
    {
        DestroyGeneratedObj();
    }

    public abstract void DestroyGeneratedObj();
}
