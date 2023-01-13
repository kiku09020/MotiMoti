using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MovingFire {
    public class Generator : GeneratorBase {

        [SerializeField] float genRangeX;

        protected override void Generate()
        {
            base.Generate(genRangeX);
        }
    }
}
