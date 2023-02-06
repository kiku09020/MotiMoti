using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DestroyerBase),true)]
public class DestroyerInspectorBase : Editor
{
    DestroyerBase destroyer;

    protected virtual void Awake()
    {
        destroyer = target as DestroyerBase;
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField("DestroyerSettings", EditorStyles.boldLabel);

        // �폜�^�C�v�w��
        destroyer.type = (DestroyerBase.DestroyType)EditorGUILayout.EnumPopup("DestroyType", destroyer.type);

        // �^�C�v���Ƃ̏���
        switch (destroyer.type) {
            case DestroyerBase.DestroyType.maxCount:        // �ő吔�
                destroyer.destroyMaxCnt = EditorGUILayout.IntField("MaxCount", destroyer.destroyMaxCnt);
                break;
            case DestroyerBase.DestroyType.distance:        // �����
                destroyer.destroyDistance = EditorGUILayout.FloatField("Distance", destroyer.destroyDistance);
                break;
        }

        EditorGUILayout.Space(10);
    }

    // GenerateCheckerTarget�̃t�B�[���h�p(�h���N���X�ŌĂяo��)
    protected void CheckerField()
    {
        destroyer.checker = (GenerateTargetChecker)EditorGUILayout.ObjectField("Checker", destroyer.checker, typeof(GenerateTargetChecker),true);
    }
}
