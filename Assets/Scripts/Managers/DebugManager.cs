using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DebugManager : MonoBehaviour
{
    /* 値 */


    /* コンポーネント取得用 */
    SceneController scene;

//-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */
        GameObject gmObj = transform.parent.gameObject;

        /* コンポーネント取得 */
        scene = gmObj.GetComponent<SceneController>();

        /* 初期化 */
        
    }

//-------------------------------------------------------------------
    void Update()
    {
        Key();
    }

    //-------------------------------------------------------------------
    // キー操作
    void Key()
    {
        // シーン再読み込み
        if (Input.GetKeyDown(KeyCode.R)) {
            scene.LoadNowScene();
        }

        else if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();

#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
        }
    }
}
