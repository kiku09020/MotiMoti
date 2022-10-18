using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    /* 値 */
    NowScene nowScene;      // 現在のシーン
    int sceneCnt;           // シーンの数

    // ロードパターン
    enum Load {
        Now,        // 現在のシーン
        Next,       // 次
        Prev,       // 前
	}

    // エラーパターン
    enum Error {
        IndexOver,      // シーン番号が大きい
        IndexLess,      // シーン番号が小さい
	}

//-------------------------------------------------------------------
    void Awake()
    {
        nowScene = new NowScene();

        nowScene.SetInfo();
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
		else {                      // 範囲外エラー処理
            LoadErrorProc(Error.IndexOver);
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
        else {                      // 範囲外エラー処理
            LoadErrorProc(Error.IndexLess);
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
        yield return new WaitForSecondsRealtime(0.2f);

		switch (loadType) {
            case Load.Now:  SceneManager.LoadScene(index);      break;
            case Load.Next: SceneManager.LoadScene(index + 1);  break;
            case Load.Prev: SceneManager.LoadScene(index - 1);  break;
        }
    }

    IEnumerator WaitLoading(string sceneName)
	{
        yield return new WaitForSecondsRealtime(0.2f);
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator WaitLoading(int sceneIndex)
	{
        yield return new WaitForSecondsRealtime(0.2f);
        SceneManager.LoadScene(sceneIndex);
    }

    //-------------------------------------------------------------------
    // エラー時の処理
    void LoadErrorProc(Error errorNum)
	{
        string errorMessage = null;

		switch (errorNum) {
            case Error.IndexOver:
                errorMessage = "指定したシーン番号が、大きすぎます";
                break;

            case Error.IndexLess:
                errorMessage = "指定したシーン番号が、小さすぎます";
                break;
		}

        // エラーメッセージ
        Debug.LogError(errorMessage);

        // エディタ上で停止させる
        Debug.Break();
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
    public void SetInfo()
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
