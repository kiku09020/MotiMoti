using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGenerateType 
{
    /// <summary>
    /// �����ʒu�̎w��
    /// </summary>
    /// <param name="nowGeneratedPos">���݂̐����ʒu</param>
    /// <param name="value">�l</param>
    Vector2 SetPosition(float y,  float value);
}
