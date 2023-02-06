using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : GeneratorSingle
{
    [Header("Ground")]
    [SerializeField,Tooltip("��]�J�n���x")] 
    float rotateStartHeight;

    protected override void GenerateBase()
    {
        // Ground�R���|�[�l���g���Ă�ꍇ�̂ݐ���
        if (targetGenObj.TryGetComponent(out Ground groundBase)) {
            Ground generatedGround = Instantiate(groundBase, generatedPos, Quaternion.identity, parent);

            // �ЂƂO�̃I�u�W�F�N�g���w�肷��
            if (GeneratedObjList?.Count > 0) {
                generatedGround.PrevStage = GeneratedObjList[GeneratedObjList.Count - 1].GetComponent<Ground>();
            }

            GeneratedObjList.Add(generatedGround.gameObject);
        }

        // �R���|�[�l���g���Ă��Ȃ��ꍇ�A�x��
        else {
            Debug.LogError($"{nameof(targetGenObj)}��{typeof(Ground).Name}�R���|�[�l���g�����Ă��܂���");
        }
    }
}
