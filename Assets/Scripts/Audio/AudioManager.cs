using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SimpleSingleton<AudioManager>
{
    // path
    const string bgmPath = "Audio/BGM";
    const string sePath = "Audio/SE";

    // AudioSource
    AudioSource bgmAS;
    List<AudioSource> seAS;

    // Dictionary
    Dictionary<string, AudioClip> bgmDic;
    Dictionary<string, AudioClip> seDic;

//-------------------------------------------------------------------
    void Awake()
    {
        
    }

    void FixedUpdate()
    {
        
    }

//-------------------------------------------------------------------

}
