using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : Generator {

    [SerializeField] protected float genRangeX;       // X”ÍˆÍ

    protected override void Generate()
    {
        GenerateBase(genRangeX);
    }
}

