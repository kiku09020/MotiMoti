using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public abstract class DestroyerBase : MonoBehaviour {
    public enum DestroyType {
        maxCount,       // �ő吔�
        distance,       // �����
    }

    [SerializeField] public DestroyType type;

    [SerializeField] public float destroyDistance;
    [SerializeField] public int destroyMaxCnt;

    [SerializeField] public GenerateTargetChecker checker;

    // �R���|�[�l���g

    //-------------------------------------------------------------------
    private void LateUpdate()
    {
        DestroyGeneratedObj();
    }

    public abstract void DestroyGeneratedObj();
}
