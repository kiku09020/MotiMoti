using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MotiAudioNames
{
    united,
    hitGround,
}

[RequireComponent(typeof(AudioSource))]
public class MotiAudioController : MonoBehaviour
{
    AudioSource source;

    [Header("Clips")]
    [SerializeField] List<AudioClip> clips;

    /* 列挙 */


    //-------------------------------------------------------------------
    void Awake()
    {
        /* オブジェクト取得 */


        /* コンポーネント取得 */
        source = GetComponent<AudioSource>();

        /* 初期化 */
    }

    public void Play(MotiAudioNames audioName)
    {
        AudioClip clip = clips[(int)audioName];
        source.PlayOneShot(clip);
    }
}
