using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Destroyer_Single))]
public class DestroyerInspector_Single : DestroyerInspectorBase
{
    Destroyer_Single destroyer;

    protected override void Awake()
    {
        base.Awake();
        
        destroyer= target as Destroyer_Single;
    }

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();

        base.OnInspectorGUI();

        EditorGUILayout.LabelField("Generator", EditorStyles.boldLabel);
        destroyer.generator = (GeneratorSingle)EditorGUILayout.ObjectField("Generator", destroyer.generator, typeof(GeneratorSingle), true);
        CheckerField();

        if (EditorGUI.EndChangeCheck()) {
            EditorUtility.SetDirty(destroyer);
        }
    }
}
