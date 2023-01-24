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
    /// ���݂̉������~��Source����clip���ēx�Đ�
    /// </summary>
    public void RePlay()
    {
        source.Stop();
        source.Play();
    }
}
