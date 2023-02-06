using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGenerateType 
{
    /// <summary>
    /// 生成位置の指定
    /// </summary>
    /// <param name="nowGeneratedPos">現在の生成位置</param>
    /// <param name="value">値</param>
    Vector2 SetPosition(float y,  float value);
}
