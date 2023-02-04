using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Destroyer_Multiple))]
public class DestroyerInspector_Multiple : DestroyerInspectorBase
{
    Destroyer_Multiple destroyer;

    protected override void Awake()
    {
        base.Awake();

        destroyer = target as Destroyer_Multiple;
    }

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();

        base.OnInspectorGUI();

        EditorGUILayout.LabelField("Generator",EditorStyles.boldLabel);
        
        destroyer.generator = (GeneratorMultiple)EditorGUILayout.ObjectField("Generator", destroyer.generator, typeof(GeneratorMultiple), true);
        CheckerField();

        if (EditorGUI.EndChangeCheck()) {
            EditorUtility.SetDirty(destroyer);
        }
    }
}
