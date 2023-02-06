using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GenerateTargetChecker),typeof(Destroyer_Multiple))]
public class GeneratorMultiple : GeneratorBase<GeneratorMultiple>
{
    [Header("生成オブジェクト")]
    [SerializeField] protected List<GameObject> generateObjList;

    //-------------------------------------------------------------------
    // リストから生成オブジェクトを指定する
    GameObject SetGeneratedObj()
    {
        var index = Random.Range(0, generateObjList.Count);
        return generateObjList[index];
    }

    protected override void GenerateBase()
    {
        // 生成するオブジェクトを指定する
        var targetGenObj = SetGeneratedObj();

        // 生成
        var generatedObj = Instantiate(targetGenObj, generatedPos, Quaternion.identity, parent);

        // 生成されたオブジェクトをリストに追加
        GeneratedObjList.Add(generatedObj);
    }
}
