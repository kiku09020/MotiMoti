using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GenerateTargetChecker),typeof(Destroyer_Single))]
[DisallowMultipleComponent]
public class GeneratorSingle : GeneratorBase<GeneratorSingle>
{
    [Header("生成オブジェクト")]
    [SerializeField] protected GameObject targetGenObj;

    //-------------------------------------------------------------------

    protected override void GenerateBase()
    {
        // 生成オブジェクト指定
        var generatedObj = Instantiate(targetGenObj, generatedPos, Quaternion.identity, parent);

        // 生成されたオブジェクトをリストに追加
        GeneratedObjList.Add(generatedObj);
    }
}
