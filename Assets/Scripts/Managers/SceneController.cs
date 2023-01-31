using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{
    /* 値 */
    const float sceneLoadWaitTime = 0.15f;

    NowScene nowScene;      // 現在のシーン
    int sceneCnt;           // シーンの数

    // ロードパターン
    enum Load {
        Now,        // 現在のシーン
        Next,       // 次
        Prev,       // 前
	}

//-------------------------------------------------------------------
    protected override void Awake()
    {
        base.Awake();

        nowScene = new NowScene();

        SceneManager.sceneLoaded += OnSceneLoaded;      // イベント追加

        sceneCnt = SceneManager.sceneCount;
    }

    //-------------------------------------------------------------------
    /// <summary>
    /// 現在のシーンを読み込む
    /// </summary>
    public void LoadNowScene(float waitDuration = 0)
    {
        StartCoroutine(WaitLoading(Load.Now, waitDuration));
    }

    /// <summary>
    /// 次のシーンを読み込む
    /// </summary>
    public void LoadNextScene(float waitDuration = 0) 
    {
        var index = nowScene.Index;
        
        if (index < sceneCnt) {     // シーン番号が合計のシーン数より小さいとき、読み込み
            StartCoroutine(WaitLoading(Load.Next, waitDuration));
        }
    }

    /// <summary>
    /// 前のシーンを読み込む
    /// </summary>
    public void LoadPrevScene(float waitDuration = 0) {
        var index = nowScene.Index;

		if (index > 0) {            // シーン番号が0より大きいとき、読み込む
            StartCoroutine(WaitLoading(Load.Prev, waitDuration));
        }
    }

    //-------------------------------------------------------------------
    /// <summary>
    /// シーン名を指定して読み込む
    /// </summary>
    public void LoadScene(string sceneName, float waitDuration = 0) 
    { StartCoroutine(WaitLoading(sceneName, waitDuration)); }

    /// <summary>
    /// シーン番号を指定して読み込む
    /// </summary>
    public void LoadScene(int sceneIndex, float waitDuration = 0)
    { StartCoroutine(WaitLoading(sceneIndex,waitDuration)); }

    //-------------------------------------------------------------------
    /* 演出+シーン読み込み */
    /// <summary>
    /// 遷移演出付きで現在のシーンを読み込む
    /// </summary>
    public void LoadNowSceneWithTransition(TransitionUI.Type transType)
    {
        TransitionUI.Instance.PlayTransition(transType);

        var duration = TransitionUI.Instance.TransitionDuration;
        LoadNowScene(duration);
    }

    /// <summary>
    /// 遷移演出付きで次のシーンを読み込む
    /// </summary>
    public void LoadNextSceneWithTransition(TransitionUI.Type transType)
    {
        TransitionUI.Instance.PlayTransition(transType);

        var duration = TransitionUI.Instance.TransitionDuration;
        LoadNextScene(duration);
    }

    /// <summary>
    /// 遷移演出付きで前のシーンを読み込む
    /// </summary>
    public void LoadPrevSceneWithTransition(TransitionUI.Type transType)
    {
        TransitionUI.Instance.PlayTransition(transType);

        var duration = TransitionUI.Instance.TransitionDuration;
        LoadPrevScene(duration);
    }

    /// <summary>
    /// 遷移演出付きでシーン番号で指定したシーンを読み込む
    /// </summary>
    public void LoadSceneWithTransition(int sceneIndex,TransitionUI.Type transType)
    {
        TransitionUI.Instance.PlayTransition(transType);

        var duration = TransitionUI.Instance.TransitionDuration;
        LoadScene(sceneIndex, duration);
    }

    /// <summary>
    /// 遷移演出付きでシーン名で指定したシーンを読み込む
    /// </summary>
    public void LoadSceneWithTransition(string sceneName, TransitionUI.Type transType)
    {
        TransitionUI.Instance.PlayTransition(transType);

        var duration = TransitionUI.Instance.TransitionDuration;
        LoadScene(sceneName, duration);
    }

    //-------------------------------------------------------------------

    /* 待機 */
    IEnumerator WaitLoading(Load loadType, float duration = 0)
	{
        var index = nowScene.Index;
        yield return new WaitForSecondsRealtime(duration);

		switch (loadType) {
            case Load.Now:  SceneManager.LoadScene(index);      break;
            case Load.Next: SceneManager.LoadScene(index + 1);  break;
            case Load.Prev: SceneManager.LoadScene(index - 1);  break;
        }
    }

    IEnumerator WaitLoading(string sceneName, float duration = 0)
	{
        yield return new WaitForSecondsRealtime(duration);
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator WaitLoading(int sceneIndex, float duration = 0)
	{
        yield return new WaitForSecondsRealtime(duration);
        SceneManager.LoadScene(sceneIndex);
    }

    //-------------------------------------------------------------------
    // ロード完了時に呼び出す
    void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        nowScene.SetUp();
        BGM.Instance.Stop();        // BGM停止
        TransitionUI.Instance.PlayTransition(TransitionUI.Type.circleOut);
    }

}

// 現在のシーン
public class NowScene 
{
    /* 変数 */
    Scene  nowScene;            // 現在のシーン
    int    nowSceneIndex;       // シーン番号
    string nowSceneName;        // シーン名

    /* 関数 */
    // 現在のシーン情報をセット
    public void SetUp()
	{
        nowScene      = SceneManager.GetActiveScene();
        nowSceneIndex = nowScene.buildIndex;
        nowSceneName  = nowScene.name;
	}

    /* プロパティ */
    public Scene Scene { get => nowScene; }

    public int    Index { get => nowSceneIndex; }
    public string Name  { get => nowSceneName; }
}
