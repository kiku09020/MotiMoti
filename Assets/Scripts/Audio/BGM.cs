using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : AudioManagerBase<BGM>
{
    protected override string FilePath { get; } = "Audio/BGM";

    //-------------------------------------------------------------------
    protected override void SetUp()
    {
        source = gameObject.AddComponent<AudioSource>();

        source.playOnAwake = false;
        source.loop = true;

        SetAudioFile();
    }

    /// <summary>
    /// 現在の音声を停止→Source内のclipを再度再生
    /// </summary>
    public void RePlay()
    {
        source.Stop();
        source.Play();
    }
}
