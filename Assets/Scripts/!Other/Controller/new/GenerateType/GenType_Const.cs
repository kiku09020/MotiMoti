using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenType_Const : IGenerateType
{
    /// <summary>
    /// ���̍��W���ɂ̂ݐ�������(���Y��)
    /// </summary>
    public Vector2 SetPosition(float y, float value)
    {
        var x = value;
        return new Vector2(x, y);
    }
}
