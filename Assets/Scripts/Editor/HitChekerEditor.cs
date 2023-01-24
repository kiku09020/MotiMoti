using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HitCheckerBase), true)]        // �p���N���X�K�p
public class HitChekerEditor : Editor
{
    HitCheckerBase _hitCheck;
    bool settingsFolder = true;

    private void Awake()
    {
        _hitCheck = target as HitCheckerBase;
    }

    //-------------------------------------------------------------------

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();

        // �R���C�_�[�w��
        _hitCheck.Collider = (Collider2D)EditorGUILayout.ObjectField("Collider", _hitCheck.Collider, typeof(Collider2D), true);

        // �w��t�H���_
        settingsFolder = EditorGUILayout.BeginFoldoutHeaderGroup(settingsFolder, "Settings");

        if (settingsFolder) {
            // ���C���[�w��
            _hitCheck.TargetLayer = EditorGUILayout.LayerField("TargetLayer", _hitCheck.TargetLayer);

            // tag�w��
            _hitCheck.TargetTag = EditorGUILayout.TagField("TargetTag", _hitCheck.TargetTag);
        }

        if (EditorGUI.EndChangeCheck()) {
            EditorUtility.SetDirty(_hitCheck);
        }
    }

}
