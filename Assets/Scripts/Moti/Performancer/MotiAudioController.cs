using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MotiAudioController : MonoBehaviour
{
    AudioSource source;

    [Header("Clips")]
    [SerializeField] List<AudioClip> clips;

    /* 列挙 */
    public enum AudioName {

    }

    //-------------------------------------------------------------------
    void Awake()
    {
        /* オブジェクト取得 */


        /* コンポーネント取得 */
        source = GetComponent<AudioSource>();

        /* 初期化 */
    }

    public void Play(AudioName audioName)
    {
        AudioClip clip = clips[(int)audioName];
        source.PlayOneShot(clip);
    }
}
