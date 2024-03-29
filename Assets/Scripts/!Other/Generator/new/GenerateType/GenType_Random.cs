using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenType_Random : IGenerateType
{
    /// <summary>
    /// ランダムに生成する
    /// </summary>
    public Vector2 SetPosition(float y, float range)
    {
        var x = Random.Range(-range, range);

        return new Vector2(x, y);
    }
}
