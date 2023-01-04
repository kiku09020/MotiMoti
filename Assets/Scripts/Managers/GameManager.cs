using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /* 値 */
    GameObject moti;

    bool isResultOnce;

    /* コンポーネント取得用 */
    BGM bgm;

    /* プロパティ */
    static public bool isResult    { get; set; }
    


//-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */
        GameObject audObj = transform.Find("AudioManager").gameObject;
        moti = GameObject.Find("Moti");

        /* コンポーネント取得 */
        bgm = audObj.GetComponent<BGM>();

        /* 初期化 */
        isResult = false;


        bgm.Play((int)BGM.AudioName.bgm2);
    }

//-------------------------------------------------------------------
    void FixedUpdate()
    {
        Result();
    }

//-------------------------------------------------------------------
    // リザルト処理
    void Result()
	{
        if (isResult) {
            if (!isResultOnce) {
                MainFireController.enable = false;          // 火止める
                MotiDistanceManager.CheckHighScore();       // ハイスコア確認
                CanvasManager.ActivateResultUI(true);       // UI表示
                ResultTexts.Instance.SetText();             // テキストセット

                CameraController.Instance.ZoomObject(moti); // カメラズーム

                isResultOnce = true;
            }
        }
    }
}
