using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : GeneratorBase {

    [SerializeField] protected float genRangeX;       // X”ÍˆÍ

    protected override void Generate()
    {
        var obj = base.Generate(genRangeX);
    }
}

