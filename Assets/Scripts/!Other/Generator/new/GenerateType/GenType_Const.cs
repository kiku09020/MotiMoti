using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenType_Const : IGenerateType
{
    /// <summary>
    /// その座標軸にのみ生成する(主にY軸)
    /// </summary>
    public Vector2 SetPosition(float y, float value)
    {
        var x = value;
        return new Vector2(x, y);
    }
}
