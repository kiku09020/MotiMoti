using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer_Multiple : DestroyerBase
{
    public GeneratorMultiple generator;

    //-------------------------------------------------------------------
    public override void DestroyGeneratedObj()
    {
        var targetObj = generator.GeneratedObjList[0];

        switch (type) {
            case DestroyType.maxCount:
                // リストの数が増えたら削除
                if (destroyMaxCnt < generator.GeneratedObjList.Count) {
                    Destroy(targetObj);
                    generator.GeneratedObjList.Remove(targetObj);
                }
                break;

            case DestroyType.distance:
                // 一番古いオブジェクトをチェック
                var targetPos = targetObj.transform.position;

                // 距離チェック
                if (checker.CheckTargetOverDistance(destroyDistance, targetPos, true)) {
                    Destroy(targetObj);
                    generator.GeneratedObjList.Remove(targetObj);
                }
                break;
        }
    }
}
