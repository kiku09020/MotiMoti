using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using Moti;

public class MotiParamViewer : EditorWindow
{
    const float verticalSpaceSize = 10;
    const float horizontalSpaceSize = 15;

    enum SpaceType {
        ver,        // vertival
        hor,        // horizontal
        flex,       // flexible
    }

    //-------------------------------------------
    [MenuItem("Debug/MotiParamViewer")]
    static void Create()
    {
        GetWindow<MotiParamViewer>("MotiParamViewer");
    }

    private void Update()
    {
        Repaint();
    }

    //-------------------------------------------
    private void OnGUI()
    {
        var obj = Selection.activeGameObject;

        // なんもないとき
        if (!obj) {
            NoneLayout();       // 表示
            return;
        }

        // タグ指定
        else if (obj.tag == "Moti") {
            var moti = obj.GetComponent<MotiController>();                                  // あんまよくないかも
            AllLayout(moti);
        }
    }

    //-------------------------------------------
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
            MotiParamLayout(moti);                              // 選択したもち(左側に表示)

            /*
            if (Application.isPlaying) {
                if (moti.Family.TargetMoti) {
                    MotiParamLayout(moti.Family.TargetMoti);    // 他のもち(右側に表示)
                }
            }

            else {
                using (new GUILayout.VerticalScope()) {
                    GUILayout.Label("None");

                    using (new GUILayout.HorizontalScope()) {
                        Space(SpaceType.flex);
                        EditorGUILayout.LabelField("aaa");
                    }
                }
            }

            */
        }

        // もち全体の情報
    }

    // もちのパラメータに関するレイアウト
    void MotiParamLayout(MotiController moti)
    {
        using (new GUILayout.VerticalScope()) {
            Space(SpaceType.ver);

            GUILayout.Label("Main",EditorStyles.boldLabel);

            // 名前
            using (new GUILayout.HorizontalScope(GUI.skin.box)) {
                Space(SpaceType.hor);

                EditorGUILayout.LabelField("Name");
                EditorGUILayout.LabelField(moti.name, EditorStyles.boldLabel);
                Space(SpaceType.flex);
            }
        }
    }

    //-------------------------------------------
    // スペース挿入
    void Space(SpaceType type)
    {
        switch (type) {
            case SpaceType.ver: GUILayout.Space(verticalSpaceSize);     break;
            case SpaceType.hor: GUILayout.Space(horizontalSpaceSize);   break;
            case SpaceType.flex:GUILayout.FlexibleSpace();              break;
        }
    }
}
