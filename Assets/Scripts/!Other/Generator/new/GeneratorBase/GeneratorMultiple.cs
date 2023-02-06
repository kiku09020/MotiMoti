using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GenerateTargetChecker),typeof(Destroyer_Multiple))]
public class GeneratorMultiple : GeneratorBase<GeneratorMultiple>
{
    [Header("�����I�u�W�F�N�g")]
    [SerializeField] protected List<GameObject> generateObjList;

    //-------------------------------------------------------------------
    // ���X�g���琶���I�u�W�F�N�g���w�肷��
    GameObject SetGeneratedObj()
    {
        var index = Random.Range(0, generateObjList.Count);
        return generateObjList[index];
    }

    protected override void GenerateBase()
    {
        // ��������I�u�W�F�N�g���w�肷��
        var targetGenObj = SetGeneratedObj();

        // ����
        var generatedObj = Instantiate(targetGenObj, generatedPos, Quaternion.identity, parent);

        // �������ꂽ�I�u�W�F�N�g�����X�g�ɒǉ�
        GeneratedObjList.Add(generatedObj);
    }
}
