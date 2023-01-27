using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yakimoti {
    public class YakimotiGenerator : EnemyGenerator {

        protected override void Generate()
        {
            GenerateBase(genRangeX, false);
        }
    }
}
