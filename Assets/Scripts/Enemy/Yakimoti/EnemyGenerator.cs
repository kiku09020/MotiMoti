using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : GeneratorBase {

    [SerializeField] float genRangeX;       // X�͈�

    protected override void Generate()
    {
        base.Generate(genRangeX);
    }
}

