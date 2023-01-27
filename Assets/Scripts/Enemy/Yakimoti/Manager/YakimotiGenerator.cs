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

        // �������擾���āA�������
        protected override void SetGeneratePosition(float range, bool containMinus)
        {
            var x = 0f;
            if (containMinus) {
                Direction = Expansion.GetRandomDirect();        // �����擾
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
