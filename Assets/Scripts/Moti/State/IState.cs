using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    public interface IState
    {
        /* プロパティ */
        public MotiController Moti { get; set; }      // コンポーネント参照用

        public void StateEnter();
        public void StateUpdate();
        public void StateExit();

        public void CheckHit();             // 色々触れた時の処理
    }
}