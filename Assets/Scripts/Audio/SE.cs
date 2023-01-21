using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : AudioManagerBase<SE>
{
    protected override string FilePath { get; } = "Audio/SE";

    //-------------------------------------------------------------------
    protected override void SetUp()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.playOnAwake = false;

        SetAudioFile();
    }
}
