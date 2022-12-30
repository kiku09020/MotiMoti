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
    void Awake()
    {
        nowScene = new NowScene();

        sceneCnt = SceneManager.sceneCount;
    }

//-------------------------------------------------------------------
    /// <summary>
    /// 現在のシーンを読み込む
    /// </summary>
    public void LoadNowScene()
    {
        StartCoroutine(WaitLoading(Load.Now));
    }

    /// <summary>
    /// 次のシーンを読み込む
    /// </summary>
    public void LoadNextScene() 
    {
        var index = nowScene.Index;
        
        if (index < sceneCnt) {     // シーン番号が合計のシーン数より小さいとき、読み込み
            StartCoroutine(WaitLoading(Load.Next));
        }
    }

    /// <summary>
    /// 前のシーンを読み込む
    /// </summary>
    public void LoadPrevScene() {
        var index = nowScene.Index;

		if (index > 0) {            // シーン番号が0より大きいとき、読み込む
            StartCoroutine(WaitLoading(Load.Prev));
        }
    }

    //-------------------------------------------------------------------
    /// <summary>
    /// シーン名を指定して読み込む
    /// </summary>
    /// <param name="sceneName">シーン名</param>
    public void LoadScene(string sceneName) 
    { StartCoroutine(WaitLoading(sceneName)); }

    /// <summary>
    /// シーン番号を指定して読み込む
    /// </summary>
    /// <param name="sceneIndex">シーン番号</param>
    public void LoadScene(int sceneIndex)
    { StartCoroutine(WaitLoading(sceneIndex)); }

    //-------------------------------------------------------------------
    /* 待機 */
    IEnumerator WaitLoading(Load loadType)
	{
        var index = nowScene.Index;
        yield return new WaitForSecondsRealtime(sceneLoadWaitTime);

		switch (loadType) {
            case Load.Now:  SceneManager.LoadScene(index);      break;
            case Load.Next: SceneManager.LoadScene(index + 1);  break;
            case Load.Prev: SceneManager.LoadScene(index - 1);  break;
        }
    }

    IEnumerator WaitLoading(string sceneName)
	{
        yield return new WaitForSecondsRealtime(sceneLoadWaitTime);
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator WaitLoading(int sceneIndex)
	{
        yield return new WaitForSecondsRealtime(sceneLoadWaitTime);
        SceneManager.LoadScene(sceneIndex);
    }

    //-------------------------------------------------------------------
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
    public NowScene()
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
