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
                // ���X�g�̐�����������폜
                if (destroyMaxCnt < generator.GeneratedObjList.Count) {
                    Destroy(targetObj);
                    generator.GeneratedObjList.Remove(targetObj);
                }
                break;

            case DestroyType.distance:
                // ��ԌÂ��I�u�W�F�N�g���`�F�b�N
                var targetPos = targetObj.transform.position;

                // �����`�F�b�N
                if (checker.CheckTargetOverDistance(destroyDistance, targetPos, true)) {
                    Destroy(targetObj);
                    generator.GeneratedObjList.Remove(targetObj);
                }
                break;
        }
    }
}
