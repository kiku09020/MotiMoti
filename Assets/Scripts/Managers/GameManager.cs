using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    /* 値 */
    [Header("ResultZooming")]
    [SerializeField] float zoomDuration = 0.5f;
    [SerializeField] float zoomSize = 3;
    [SerializeField] Ease easeType;

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
                var moti = GameObject.Find("Moti");

                MainFireController.enable = false;          // 火止める
                MotiDistanceManager.CheckHighScore();       // ハイスコア確認
                CanvasManager.ActivateResultUI(true);       // UI表示
                ResultTexts.Instance.SetText();             // テキストセット

                CameraController.Instance.ZoomIn(moti, zoomDuration, zoomSize, easeType); // カメラズーム

                isResultOnce = true;
            }
        }
    }
}
