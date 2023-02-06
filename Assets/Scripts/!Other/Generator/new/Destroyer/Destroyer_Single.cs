using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer_Single : DestroyerBase
{
    [SerializeField] public GeneratorSingle generator;

    //-------------------------------------------------------------------
    public override void DestroyGeneratedObj()
    {
        GameObject generatedObj = null;

        if (generator.GeneratedObjList?.Count > 0) {
            generatedObj = generator.GeneratedObjList[0];

            if (generatedObj) {
                switch (type) {
                    case DestroyType.maxCount:
                        // リストの数が増えたら削除
                        if (destroyMaxCnt < generator.GeneratedObjList.Count) {
                            Destroy(generatedObj);
                            generator.GeneratedObjList.Remove(generatedObj);
                        }
                        break;

                    case DestroyType.distance:
                        // 一番古いオブジェクトをチェック
                        var targetPos = generatedObj.transform.position;

                        // 距離チェック
                        if (checker.CheckTargetOverDistance(destroyDistance, targetPos, true)) {
                            if (targetPos.y < checker.TargetObj.transform.position.y) {
                                Destroy(generatedObj);
                                generator.GeneratedObjList.Remove(generatedObj);
                            }
                        }
                        break;
                }
            }
        }
    }
}
