using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;
using UnityEditor;

using Moti;

public class MotiParamViewer : EditorWindow
{
    // スペース
    const float verticalSpaceSize = 10;         // 縦スペースサイズ
    const float horizontalSpaceSize = 15;       // 横スペースサイズ

    enum SpaceType  {       // スペースの種類
        ver,        // vertival
        hor,        // horizontal
        flex,       // flexible
    }

    // 色
    Color defaultBGColor;     // デフォ背景色

    // 折りたたみ
    bool[] folders = new bool[Enum.GetNames(typeof(FolderType)).Length];        // 配列

    enum FolderType{        // タイプ名
        Ground,
        Motihit,
        Input,
        Family,
        Stretcher,
        Line,
    }

    //-------------------------------------------
    #region Events

    [MenuItem("Debug/MotiParamViewer")]
    static void Create()
    {
        var window = GetWindow<MotiParamViewer>("MotiParamViewer");
    }

    // 毎フレーム更新(重くなりそう)
    private void Update()
    {
        Repaint();
    }

    private void OnGUI()
    {
        var obj = Selection.activeGameObject;       // 選択されたオブジェクト

        // なんもないとき
        if (!obj) {
            NoneLayout();       // 選択指示を表示
        }

        // タグ指定
        else if (obj.tag == "Moti") {
            var moti = obj.GetComponent<MotiController>();      // あんまよくないかも
            AllLayout(moti);
        }
    }

    #endregion
    //-------------------------------------------
    #region Templates
    // スペース挿入
    void Space(SpaceType type)
    {
        switch (type) {
            case SpaceType.ver: GUILayout.Space(verticalSpaceSize); break;
            case SpaceType.hor: GUILayout.Space(horizontalSpaceSize); break;
            case SpaceType.flex: GUILayout.FlexibleSpace(); break;
        }
    }

    // 折りたたみテンプレ
    bool FolderTemplate(bool flag, string itemName, int index, MotiController moti)
    {
        flag = EditorGUILayout.BeginFoldoutHeaderGroup(flag, itemName);
        if (flag) {
            FolderFunction(index, moti);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        return flag;
    }

    // ラベルテンプレ
    void LabelTemplate(string itemName, string text)
    {
        using (new GUILayout.HorizontalScope(GUI.skin.box)) {
            Space(SpaceType.hor);

            EditorGUILayout.LabelField(itemName);                       // itemName

            GUI.backgroundColor = Color.gray;
            EditorGUILayout.LabelField(text, GUI.skin.textField);       // text
            GUI.backgroundColor = defaultBGColor;

            Space(SpaceType.flex);
        }
    }

    // ベクトル値テンプレ
    void VectorTemplate(string itemName,Vector2 value)
    {
        using (new GUILayout.HorizontalScope(GUI.skin.box)) {
            Space(SpaceType.hor);

            EditorGUILayout.LabelField(itemName);

            GUI.backgroundColor = Color.gray;
            EditorGUILayout.LabelField(value.x.ToString("F2"), GUI.skin.textField);
            EditorGUILayout.LabelField(value.y.ToString("F2"), GUI.skin.textField);
            GUI.backgroundColor = defaultBGColor;

            Space(SpaceType.flex);
        }
    }

    // フラグテンプレ
    void BoolTemplate(string itemName, bool value)
    {
        using (new GUILayout.HorizontalScope(GUI.skin.box)) {
            Space(SpaceType.hor);

            EditorGUILayout.LabelField(itemName);

            var str = "";
            str = value ? "☑" : "□";
            EditorGUILayout.LabelField(str);

            Space(SpaceType.flex);
        }
    }

    #endregion
    //-------------------------------------------
    #region Layouts
    // もち選択指示
    void NoneLayout()
    {
        using (new GUILayout.VerticalScope()) {
            Space(SpaceType.flex);
            using (new GUILayout.HorizontalScope()) {
                Space(SpaceType.flex);

                // ラベル表示(中央寄せ)
                EditorGUILayout.LabelField("Hierarchy上でもちを選択すると、\nパラメーターが表示されます",
                                            EditorStyles.boldLabel  ,
                                            GUILayout.Height(300));
                Space(SpaceType.flex);
            }
            Space(SpaceType.flex);
        }
    }

    // 全てまとめたレイアウト
    void AllLayout(MotiController moti)
    {
        // もち単体の情報
        using (new GUILayout.HorizontalScope()) {
            MotiParamLayout(moti,true);                              // 選択したもち(左側に表示)

            
            if (Application.isPlaying) {
                if (moti.Family.OtherMoti) {
                    MotiParamLayout(moti.Family.OtherMoti,false);    // 他のもち(右側に表示)
                }
            }

            else {
                NoneLayout();
            }
        }

        // もち全体の情報
    }

    // もちのパラメータに関するレイアウト
    void MotiParamLayout(MotiController moti,bool isMain)
    {
        defaultBGColor = GUI.backgroundColor;

        using (new GUILayout.VerticalScope(GUI.skin.box)) {
            Space(SpaceType.ver);

            // 見出し
            var label = isMain ? "Main" : "Other";              // ラベル内容指定
            GUILayout.Label(label, EditorStyles.boldLabel);     // ラベル表示

            // オブジェクト名
            LabelTemplate("Name", moti.name);

            // 位置
            VectorTemplate("Position", moti.transform.position);

            // ※プレイ中にのみ表示する
            if (Application.isPlaying) {
                // 状態
                LabelTemplate("State", moti.StateCtrl.NowState.ToString()) ;

                // Folders
                for(int i = 0; i < folders.Length; i++) {
                    var fldr = folders[i];
                    var str = Enum.GetNames(typeof(FolderType))[i];

                    folders[i] = FolderTemplate(fldr, str, i, moti);
                }
            }
        }
    }

    #endregion

    #region Functions
    // 折りたたみごとの処理をまとめたやつ
    void FolderFunction(int index,MotiController moti)
    {
        switch (index) {
            case (int)FolderType.Ground:        GroundFolder(moti);     break;
            case (int)FolderType.Motihit:       MotiHitFolder(moti);    break;
            case (int)FolderType.Input:         InputFolder(moti);      break;
            case (int)FolderType.Family:        FamilyFolder(moti);     break;
            case (int)FolderType.Stretcher:     StretcherFolder(moti);  break;
            case (int)FolderType.Line:          LineFolder(moti);       break;
        }
    }

    void GroundFolder(MotiController moti)
    {
        BoolTemplate("IsGround",moti.Ground.IsGround);
        VectorTemplate("HitPoint", moti.Ground.HitPoint);
        VectorTemplate("HitVector", moti.Ground.HitVector);
    }

    void MotiHitFolder(MotiController moti)
    {
        BoolTemplate("IsHitMoti", moti.MotiHit.IsMotiTrigger);
    }

    void InputFolder(MotiController moti)
    {
        BoolTemplate("IsTapping", moti.Input.IsTapping);
        BoolTemplate("IsDragging", moti.Input.IsDraging);
        BoolTemplate("IsOnMouse", moti.Input.IsOnMoti);
    }

    void FamilyFolder(MotiController moti)
    {
        BoolTemplate("IsSingle", moti.Family.IsSingle);
        BoolTemplate("HasChild", moti.Family.HasChild);
        BoolTemplate("HasParent", moti.Family.HasParent);
    }

    void StretcherFolder(MotiController moti)
    {
        BoolTemplate("IsStretching", moti.Stretcher.IsStretching);
    }

    void LineFolder(MotiController moti)
    {
        if (moti.Family.HasChild) {
            LabelTemplate("Length", moti.Line.Length.ToString());
            BoolTemplate("IsLimit", moti.Line.IsLengthLimit);
        }

        else {
            EditorGUILayout.HelpBox("This Moti hasn`t line.", MessageType.Info);
        }
    }

    #endregion
}
