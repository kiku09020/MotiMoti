using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    public abstract class MotiState:StateBase
    {
        /* プロパティ */
        public MotiController Moti { get; protected set; }      // コンポーネント参照用

        public abstract void CheckHit();             // 色々触れた時の処理

        private void Awake()
        {
            Moti = GetComponent<MotiController>();
        }
    }
}