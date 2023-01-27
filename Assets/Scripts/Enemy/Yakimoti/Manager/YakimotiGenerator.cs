using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yakimoti {
    public class YakimotiGenerator : EnemyGenerator {

        public int Direction { get; private set; }

        protected override void Generate()
        {
            var obj = GenerateBase(genRangeX, false);
            var ykmt = obj.GetComponent<Yakimoti>();

            ykmt.xDir = Direction;
        }

        // •ûŒü‚ğæ“¾‚µ‚ÄA‘ã“ü‚·‚é
        protected override void SetGeneratePosition(float range, bool containMinus)
        {
            var x = 0f;
            if (containMinus) {
                Direction = Expansion.GetRandomDirect();        // •ûŒüæ“¾
                x = range * Direction;
            }

            else {
                x = range;
            }

            var y = genPos.y + genObjDist;
            genPos = new Vector2(x, y);
        }
    }
}
