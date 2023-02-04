using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenType_Const : IGenerateType
{
    /// <summary>
    /// ÇªÇÃç¿ïWé≤Ç…ÇÃÇ›ê∂ê¨Ç∑ÇÈ(éÂÇ…Yé≤)
    /// </summary>
    public Vector2 SetPosition(float y, float value)
    {
        var x = value;
        return new Vector2(x, y);
    }
}
