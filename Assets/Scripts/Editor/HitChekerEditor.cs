using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HitCheckerBase), true), CanEditMultipleObjects]        // 継承クラス適用、プレハブでも操作可能
public class HitChekerEditor : Editor
{
    HitCheckerBase _hitCheck;
    bool settingsFolder;

    private void Awake()
    {
        _hitCheck = target as HitCheckerBase;
    }

    //-------------------------------------------------------------------

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();

        // コライダー指定
        _hitCheck.Collider = (Collider2D)EditorGUILayout.ObjectField("Collider", _hitCheck.Collider, typeof(Collider2D), true);

        // 指定フォルダ
        settingsFolder = EditorGUILayout.BeginFoldoutHeaderGroup(settingsFolder, "Settings");

        if (settingsFolder) {
            // レイヤー指定
            _hitCheck.TargetLayer = EditorGUILayout.LayerField("TargetLayer", _hitCheck.TargetLayer);

            // tag指定
            _hitCheck.TargetTag = EditorGUILayout.TagField("TargetTag", _hitCheck.TargetTag);
        }

        if (EditorGUI.EndChangeCheck()) {
            EditorUtility.SetDirty(_hitCheck);
        }
    }

}
