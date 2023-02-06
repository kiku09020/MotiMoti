using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer_Multiple : DestroyerBase
{
    [SerializeField] public GeneratorMultiple generator;

    //-------------------------------------------------------------------
    public override void DestroyGeneratedObj()
    {
        GameObject generatedObj=null;

        if (generator.GeneratedObjList?.Count > 0)  {
            generatedObj = generator.GeneratedObjList[0];

            if (generatedObj) {
                switch (type) {
                    case DestroyType.maxCount:
                        // ���X�g�̐�����������폜
                        if (destroyMaxCnt < generator.GeneratedObjList.Count) {
                            Destroy(generatedObj);
                            generator.GeneratedObjList.Remove(generatedObj);
                        }
                        break;

                    case DestroyType.distance:
                        // ��ԌÂ��I�u�W�F�N�g���`�F�b�N
                        var genObjPos = generatedObj.transform.position;

                        // �����`�F�b�N
                        if (checker.CheckTargetOverDistance(destroyDistance, genObjPos, true)) {
                            if (genObjPos.y < checker.TargetObj.transform.position.y) {
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
