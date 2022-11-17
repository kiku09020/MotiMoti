using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DebugManager : MonoBehaviour
{
    /* 値 */
    [SerializeField] int motiMaxCount;      // もちの最大数

    GameObject[] motis;                     // もちの配列

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
        ErrorCheck();
    }

    //-------------------------------------------------------------------
    // キー操作
    void Key()
    {
        // シーン再読み込み
        if (Input.GetKeyDown(KeyCode.R)) {
            scene.LoadNowScene();
            Debug.ClearDeveloperConsole();
        }

        else if (Input.GetKeyDown(KeyCode.Escape)) {
            QuitGame();
        }
    }

    // エラーチェック
    void ErrorCheck()
    {
        motis = GameObject.FindGameObjectsWithTag("Moti");

        // 多くなりすぎたら、プレイ中止
        if (motis.Length > motiMaxCount) {
            QuitGame();
            Debug.LogError("もちの数が多すぎます");
        }
    }

    // ゲーム終了
    void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
}
