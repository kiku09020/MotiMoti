using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expansion : MonoBehaviour
{
    public static int GetRandomDirect()
    {
        // Range(0 or 1)
        var value = Random.Range(0, 2);

        // value��-1�ɂ��� 
        if (value == 0) {
            value = -1;
        }
        return value;
    }
}
