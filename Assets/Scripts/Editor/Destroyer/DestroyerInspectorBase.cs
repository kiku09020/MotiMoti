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

        // 削除タイプ指定
        destroyer.type = (DestroyerBase.DestroyType)EditorGUILayout.EnumPopup("DestroyType", destroyer.type);

        // タイプごとの処理
        switch (destroyer.type) {
            case DestroyerBase.DestroyType.maxCount:        // 最大数基準
                destroyer.destroyMaxCnt = EditorGUILayout.IntField("MaxCount", destroyer.destroyMaxCnt);
                break;
            case DestroyerBase.DestroyType.distance:        // 距離基準
                destroyer.destroyDistance = EditorGUILayout.FloatField("Distance", destroyer.destroyDistance);
                break;
        }

        EditorGUILayout.Space(10);
    }

    // GenerateCheckerTargetのフィールド用(派生クラスで呼び出し)
    protected void CheckerField()
    {
        destroyer.checker = (GenerateTargetChecker)EditorGUILayout.ObjectField("Checker", destroyer.checker, typeof(GenerateTargetChecker),true);
    }
}
