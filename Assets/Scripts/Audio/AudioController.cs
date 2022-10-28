using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    /* 値 */


    /* フラグ */


    /* プロパティ */


    /* コンポーネント取得用 */

//-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */

        /* コンポーネント取得 */
    }

    void FixedUpdate()
    {
        
    }

//-------------------------------------------------------------------
    // 音声をミュートする
    public void MuteAudio()
    {
        AudioListener.volume = 0;
    }

    // 音声のミュートを解除する
    public void UnmuteAudio()
    {
        AudioListener.volume = 1;
    }
}
