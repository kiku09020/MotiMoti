using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    public interface IState:IStateBase
    {
        /* プロパティ */
        public MotiController Moti { get; set; }      // コンポーネント参照用

        public void CheckHit();             // 色々触れた時の処理
    }
}