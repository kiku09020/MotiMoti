using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenType_Random : IGenerateType
{
    /// <summary>
    /// �����_���ɐ�������
    /// </summary>
    public Vector2 SetPosition(float y, float range)
    {
        var x = Random.Range(-range, range);

        return new Vector2(x, y);
    }
}
