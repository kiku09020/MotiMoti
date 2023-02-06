using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenType_Edge : IGenerateType
{
    /// <summary>
    /// �[�ɂ̂ݐ�������
    /// </summary>
    public Vector2 SetPosition(float y, float edge)
    {
        var x = edge * Expansion.GetRandomDirect();

        return new Vector2(x, y);
    }
}
