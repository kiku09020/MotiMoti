using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AudioManagerBase<T> : Singleton<T> where T:AudioManagerBase<T> {
    // path
    protected abstract string FilePath { get; }

    protected AudioSource source;   // source
    protected Dictionary<string, AudioClip> dic;    // dic

//-------------------------------------------------------------------
    protected override void Awake()
    {
        base.Awake();

        SetUp();
    }

    //-------------------------------------------------------------------
    // 準備
    protected abstract void SetUp();

    // AudioFileを指定
    protected void SetAudioFile()
    {
        dic = new Dictionary<string, AudioClip>();
        object[] list = Resources.LoadAll(FilePath);

        foreach (AudioClip clip in list) {
            dic[clip.name] = clip;
        }
    }

    //-------------------------------------------------------------------
    /// <summary>
    /// 音声再生
    /// </summary>
    /// <remarks>第二引数以降に遅延、音量倍率、ピッチなどを指定できます</remarks>
    /// <param name="audioName">音声ファイル名</param>
    /// <param name="delay">遅延</param>
    /// <param name="volume">音量</param>
    /// <param name="pitch">ピッチ</param>
    public virtual void Play(string audioName, float delay = 0, float volume = 1, float pitch = 1)
    {
        // 存在しない場合
        if (!dic.ContainsKey(audioName)) {
            print($"{audioName}という名前のファイルはないよん");
            return;
        }

        // 存在する場合
        else {
            StartCoroutine(PlayBase(audioName, delay, volume, pitch));
        }
    }

    // Invoke用
    IEnumerator PlayBase(string audioName,float delay,float volume=1,float pitch=1)
    {
        yield return new WaitForSecondsRealtime(delay);

        source.volume = volume;
        source.pitch = pitch;

        var clip = dic[audioName];
        source.clip = clip;
        source.PlayOneShot(clip);
    }

    //-------------------------------------------------------------------
    /// <summary>
    /// 音声をポーズ
    /// </summary>
    public virtual void Pause()
    {
        source.Pause();
    }

    /// <summary>
    /// 音声のポーズを解除
    /// </summary>
    public virtual void UnPause()
    {
        source.UnPause();
    }

    /// <summary>
    /// 音声の再生を停止
    /// </summary>
    public void Stop()
    {
        source.Stop();
    }

    //-------------------------------------------------------------------
    /* ChangeProperty */

    /// <summary>
    /// ミュート
    /// </summary>
    public void Mute()
    {
        source.mute = true;
    }

    public void UnMute()
    {
        source.mute = false;
    }

    /// <summary>
    /// 音量変更
    /// </summary>
    public void ChangeVolume(float volume)
    {
        source.volume = volume;
    }

    /// <summary>
    /// ピッチ変更
    /// </summary>
    public void ChangePitch(float pitch)
    {
        source.pitch = pitch;
    }

    /* AddProperty */
    /// <summary>
    /// 音量加算
    /// </summary>
    public void AddVolume(float addVolumeValue)
    {
        source.volume += addVolumeValue;
    }

    /// <summary>
    /// ピッチ加算
    /// </summary>
    public void AddPitch(float addPitchValue)
    {
        source.pitch += addPitchValue;
    }
}
