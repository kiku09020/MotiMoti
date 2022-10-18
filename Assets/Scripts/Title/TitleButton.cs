using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleButton : ButtonManager
{
    /* 値 */


    /* フラグ */


    /* プロパティ */


    /* コンポーネント取得用 */
    AudioManager _aud;

    SceneController _scene;

    //-------------------------------------------------------------------
    void Awake()
    {
        /* オブジェクト取得 */
        GameObject tmObj = GameObject.Find("TitleManager");
        GameObject audObj = tmObj.transform.Find("AudioManager").gameObject;

        /* コンポーネント取得 */
        _aud = audObj.GetComponent<AudioManager>();
        _scene = tmObj.GetComponent<SceneController>();

        /* 初期化 */

    }

    void FixedUpdate()
    {

    }

    //-------------------------------------------------------------------
    public void GameStart()
    {
        PlayButtonAudio(Audio.Decision, _aud);

        _scene.LoadScene("Main");
    }
}
