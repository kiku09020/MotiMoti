using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerBase_old : MonoBehaviour
{
    Generator gen;

//-------------------------------------------------------------------
    void Awake()
    {
        gen = GetComponent<Generator>();
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
        if (gen.MaxCnt < gen.GenObjList.Count) {
            gen.GenObjList.RemoveAt(0);
            Destroy(gen.GenObjList[0]);
        }
    }
}
