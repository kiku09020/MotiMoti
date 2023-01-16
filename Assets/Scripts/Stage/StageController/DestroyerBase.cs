using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerBase : MonoBehaviour
{
    GeneratorBase gen;

//-------------------------------------------------------------------
    void Awake()
    {
        gen = GetComponent<GeneratorBase>();
    }

    void FixedUpdate()
    {
        if (!GameManager.isResult) {
            CheckDestroyable();
        }
    }

    //-------------------------------------------------------------------
    void CheckDestroyable()
    {
        if (gen.MaxCnt < gen.GenObjects.Count) {
            gen.GenObjects.RemoveAt(0);
            Destroy(gen.GenObjects[0]);
        }
    }
}
