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
    // ����
    protected abstract void SetUp();

    // AudioFile���w��
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
    /// �����Đ�
    /// </summary>
    /// <remarks>�������ȍ~�ɒx���A���ʔ{���A�s�b�`�Ȃǂ��w��ł��܂�</remarks>
    /// <param name="audioName">�����t�@�C����</param>
    /// <param name="delay">�x��</param>
    /// <param name="volume">����</param>
    /// <param name="pitch">�s�b�`</param>
    public virtual void Play(string audioName, float delay = 0, float volume = 1, float pitch = 1)
    {
        // ���݂��Ȃ��ꍇ
        if (!dic.ContainsKey(audioName)) {
            print($"{audioName}�Ƃ������O�̃t�@�C���͂Ȃ����");
            return;
        }

        // ���݂���ꍇ
        else {
            StartCoroutine(PlayBase(audioName, delay, volume, pitch));
        }
    }

    // Invoke�p
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
    /// �������|�[�Y
    /// </summary>
    public virtual void Pause()
    {
        source.Pause();
    }

    /// <summary>
    /// �����̃|�[�Y������
    /// </summary>
    public virtual void UnPause()
    {
        source.UnPause();
    }

    /// <summary>
    /// �����̍Đ����~
    /// </summary>
    public void Stop()
    {
        source.Stop();
    }

    //-------------------------------------------------------------------
    /* ChangeProperty */

    /// <summary>
    /// �~���[�g
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
    /// ���ʕύX
    /// </summary>
    public void ChangeVolume(float volume)
    {
        source.volume = volume;
    }

    /// <summary>
    /// �s�b�`�ύX
    /// </summary>
    public void ChangePitch(float pitch)
    {
        source.pitch = pitch;
    }

    /* AddProperty */
    /// <summary>
    /// ���ʉ��Z
    /// </summary>
    public void AddVolume(float addVolumeValue)
    {
        source.volume += addVolumeValue;
    }

    /// <summary>
    /// �s�b�`���Z
    /// </summary>
    public void AddPitch(float addPitchValue)
    {
        source.pitch += addPitchValue;
    }
}
