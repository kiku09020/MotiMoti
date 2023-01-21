using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : Singleton<AudioController>
{
    /// <summary>
    /// �S�Ẳ������|�[�Y
    /// </summary>
    public void PauseAllAudio()
    {
        BGM.Instance.Pause();
        SE.Instance.Pause();
    }

    /// <summary>
    /// �S�Ẳ����̃|�[�Y������
    /// </summary>
    public void UnPauseAllAudio()
    {
        BGM.Instance.UnPause();
        SE.Instance.UnPause();
    }


    /// <summary>
    /// �S�Ẳ����̍Đ����~
    /// </summary>
    public void StopAllAudio()
    {
        BGM.Instance.Stop();
        SE.Instance.Stop();
    }
}
