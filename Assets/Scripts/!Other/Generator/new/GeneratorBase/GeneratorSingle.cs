using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GenerateTargetChecker),typeof(Destroyer_Single))]
[DisallowMultipleComponent]
public class GeneratorSingle : GeneratorBase<GeneratorSingle>
{
    [Header("�����I�u�W�F�N�g")]
    [SerializeField] protected GameObject targetGenObj;

    //-------------------------------------------------------------------

    protected override void GenerateBase()
    {
        // �����I�u�W�F�N�g�w��
        var generatedObj = Instantiate(targetGenObj, generatedPos, Quaternion.identity, parent);

        // �������ꂽ�I�u�W�F�N�g�����X�g�ɒǉ�
        GeneratedObjList.Add(generatedObj);
    }
}
