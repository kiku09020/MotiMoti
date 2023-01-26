using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : SimpleSingleton<TimeController>
{
    /// <summary>
    /// �b���w��Œ�~
    /// </summary>
    public void WaitSecond(float waitTime)
    {
        StartCoroutine(WaitSecondBase(waitTime));
    }

    IEnumerator WaitSecondBase(float waitTime)
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(waitTime);
        Time.timeScale = 1;
    }

    //-------------------------------------------------------------------
    /// <summary>
    /// �t���[���w��Œ�~
    /// </summary>
    public void WaitFrame(int frame)
    {
        StartCoroutine(WaitFrameBase(frame));
    }

    IEnumerator WaitFrameBase(int frame)
    {
        for(int i = 0; i < frame; i++) {
            yield return null;
        }
    }

    //-------------------------------------------------------------------
    /// <summary>
    /// timeScale��ύX
    /// </summary>
    /// <param name="targetTimeScale"></param>
    public void ChangeTimeScale(float targetTimeScale)
    {
        Time.timeScale = targetTimeScale;
    }

    /// <summary>
    /// timeScale�����X�ɕύX
    /// </summary>
    public void ChangeTimeScale(float targetTimeScale,float changeSpeed)
    {
        Time.timeScale = Mathf.Lerp(Time.timeScale, targetTimeScale, Time.deltaTime * changeSpeed);   
    }
}
