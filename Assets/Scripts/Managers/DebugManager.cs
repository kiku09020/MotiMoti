using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Log();
    }

    //-------------------------------------------------------------------
    // キー操作
    void Key()
    {
        // シーン再読み込み
        if (Input.GetKeyDown(KeyCode.R)) {
            scene.LoadScene(SceneController.Load.Now);
        }
    }

    // ログ出力
    void Log()
    {

    }
}
