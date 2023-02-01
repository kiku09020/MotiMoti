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

    [Header("BGM")]
    [SerializeField,Range(0,1)] float bgmDelay = 0.5f;
    [SerializeField,Range(0,1)] float bgmVolume = 0.5f;

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

        BGM.Instance.Play("bgm1", bgmDelay, bgmVolume);     // BGM再生
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
                StartCoroutine(TimeStop(timeStop));
            }
        }
    }

    // 入った瞬間
    void ResultEnterFunc()
	{
        BGM.Instance.Stop();        // BGM停止
        SE.Instance.Play("hitEnemy");
    }

    // 停止後
    void ResultAfterFunc()
    {
        FireController.Instance.SetEnable(false);   // 火を止める
        MotiDistanceManager.CheckHighScore();       // ハイスコア確認
        CanvasManager.ActivateResultUI(true);       // UI表示
        ResultTexts.Instance.SetText();             // テキストセット

        isResultOnce = true;
    }

    IEnumerator TimeStop(float time)
    {
        ResultEnterFunc();

        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(time);
        Time.timeScale = 1;

        ResultAfterFunc();
    }
}
