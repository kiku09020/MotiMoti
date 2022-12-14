using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioBasic : MonoBehaviour 
{
    [SerializeField] protected AudioSource source;
    [SerializeField] protected List<AudioClip> clips;

    public virtual void Play(int audio)
    {
        AudioClip clip = clips[audio];
        source.PlayOneShot(clip);
    }

    // 音声の一時停止
    public void Pause()
    {
        source.Pause();
    }

    // ポーズ解除
    public void Unpause()
    {
        source.UnPause();
    }
}
