using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    /* 値 */

    public enum Audio {
        Decision,       // 決定音
        Cancel,         // キャンセル音
    }

    /* コンポーネント取得用 */
    GameManager gm;
    CanvasManager canvas;
    AudioManager aud;
    SceneController scene;
    PauseManager pause;

    //-------------------------------------------------------------------
    void Awake()
    {
        /* オブジェクト取得 */
        GameObject gmObj  = GameObject.Find("GameManager");
        GameObject umObj  = gmObj.transform.Find("UIManager").gameObject;
        GameObject audObj = gmObj.transform.Find("AudioManager").gameObject;

        /* コンポーネント取得 */
        gm      = gmObj.GetComponent<GameManager>();
        canvas  = umObj.GetComponent<CanvasManager>();
        aud     = audObj.GetComponent<AudioManager>();
        scene   = gmObj.GetComponent<SceneController>();
        pause   = gmObj.GetComponent<PauseManager>();

        /* 初期化 */
        
    }

    //-------------------------------------------------------------------
    // クリック時の音声再生
    protected void PlayButtonAudio(Audio audType)
    {
        switch (audType) {
            case Audio.Decision:
                aud.PlaySE(AudioEnum.Enm_AudSrc.SE_UI, (int)AudioEnum.Enm_SE_UI.click);
                break;

            case Audio.Cancel:
                aud.PlaySE(AudioEnum.Enm_AudSrc.SE_UI, (int)AudioEnum.Enm_SE_UI.cancel);
                break;
        }
    }

    // AudioManager指定(タイトルとか用。めんどい。要改良)
    protected void PlayButtonAudio(Audio audType,AudioManager am)
    {
        switch (audType) {
            case Audio.Decision:
                am.PlaySE(AudioEnum.Enm_AudSrc.SE_UI, (int)AudioEnum.Enm_SE_UI.click);
                break;

            case Audio.Cancel:
                am.PlaySE(AudioEnum.Enm_AudSrc.SE_UI, (int)AudioEnum.Enm_SE_UI.cancel);
                break;
        }
    }

    //-------------------------------------------------------------------
    // ポーズ時に音声を一時停止する
    public void Pause(bool pause)
    {
        gm.IsPause = pause;     // 停止中フラグ
        canvas.Pause(pause);    // キャンバスのフラグ
        aud.PauseAudio(pause);

        // ポーズ時
        if (pause) {
            Time.timeScale = 0;
            PlayButtonAudio(Audio.Decision);
        }

        // ポーズ終了時
        else {
            Time.timeScale = 1;
            PlayButtonAudio(Audio.Cancel);
        }
    }

    // リトライボタン(引数：ポーズ中か)
    public void Retry(bool isPausing)
    {
        PlayButtonAudio(Audio.Decision);

        // ポーズ中の処理
        if (isPausing) {
            pause.isRetry = true;
            pause.SetCaution();
            canvas.Caution(true);
        }

        // ポーズ画面じゃないとき、Yesボタン押したときなど
        else {
            Time.timeScale = 1;
            scene.LoadNowScene();
        }
    }

    // ゲーム終了ボタン(引数：ポーズ中か)
    public void Exit(bool isPausing)
    {
        PlayButtonAudio(Audio.Decision);

        // ポーズ中の処理
        if (isPausing) {
            pause.isExit = true;
            pause.SetCaution();
            canvas.Caution(true);
        }

        // ポーズ画面じゃないとき、Yesボタン押したときなど
        else {
            Time.timeScale = 1;
            scene.LoadScene("Title");
        }
    }

    //-------------------------------------------------------------------
    /* 警告表示内のボタン */
    // Yesボタン
    public void CautionButton_Yes()
    {
        PlayButtonAudio(Audio.Decision);
        Time.timeScale = 1;

        // リトライ
        if (pause.isRetry) {
            Retry(false);
        }

        // タイトルに戻る
        if (pause.isExit) {
            Exit(false);
        }
    }

    // Noボタン
    public void CautionButton_No()
    {
        canvas.Caution(false);      // 非表示
        pause.isExit = false;
        pause.isRetry = false;
    }
}
