using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : Singleton<AudioController>
{
    /// <summary>
    /// 全ての音声をポーズ
    /// </summary>
    public void PauseAllAudio()
    {
        BGM.Instance.Pause();
        SE.Instance.Pause();
    }

    /// <summary>
    /// 全ての音声のポーズを解除
    /// </summary>
    public void UnPauseAllAudio()
    {
        BGM.Instance.UnPause();
        SE.Instance.UnPause();
    }


    /// <summary>
    /// 全ての音声の再生を停止
    /// </summary>
    public void StopAllAudio()
    {
        BGM.Instance.Stop();
        SE.Instance.Stop();
    }
}
