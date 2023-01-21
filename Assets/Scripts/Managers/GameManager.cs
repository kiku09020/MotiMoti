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

    [Header("Result")]
    [SerializeField] float timeStop;

    bool isResultOnce;

    /* プロパティ */
    static public bool isResult    { get; set; }
    


//-------------------------------------------------------------------
    void Start()
    {
        /* 初期化 */
        isResult = false;
        isResultOnce = false;

        Time.timeScale = 1;

        BGM.Instance.Play("bgm1", 1, 0.2f);
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
                var moti = GameObject.Find("Moti").GetComponent<Moti.MotiController>();

                if (moti.Family.OtherMoti) {
                    // カメラズーム
                    CameraController.Instance.ZoomIn(moti.Family?.OtherMoti.gameObject,
                                                    zoomDuration, zoomSize, easeType);
                }

                StartCoroutine(TimeStop(timeStop));
            }
        }
    }

    void ResultFunc()
    {
        var moti = GameObject.Find("Moti");
        CameraController.Instance.ZoomOut(moti);

        FireController.enable = false;          // 火止める
        MotiDistanceManager.CheckHighScore();       // ハイスコア確認
        CanvasManager.ActivateResultUI(true);       // UI表示
        ResultTexts.Instance.SetText();             // テキストセット
        isResultOnce = true;
    }

    IEnumerator TimeStop(float time)
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(time);
        Time.timeScale = 1;

        ResultFunc();
    }
}
