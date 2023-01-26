using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : SimpleSingleton<TimeController>
{
    /// <summary>
    /// 秒数指定で停止
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
    /// フレーム指定で停止
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
    /// timeScaleを変更
    /// </summary>
    /// <param name="targetTimeScale"></param>
    public void ChangeTimeScale(float targetTimeScale)
    {
        Time.timeScale = targetTimeScale;
    }

    /// <summary>
    /// timeScaleを徐々に変更
    /// </summary>
    public void ChangeTimeScale(float targetTimeScale,float changeSpeed)
    {
        Time.timeScale = Mathf.Lerp(Time.timeScale, targetTimeScale, Time.deltaTime * changeSpeed);   
    }
}
