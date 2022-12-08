using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    public interface IState
    {
        /* プロパティ */
        public MotiController Moti { get; set; }      // コンポーネント参照用

        /* メソッド */
        public void StateEnter();           // 状態に入った瞬間
        public void StateUpdate();          // 状態の更新処理
        public void StateExit();            // 状態を出た瞬間
    }
}