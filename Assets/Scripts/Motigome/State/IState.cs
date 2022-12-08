using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Motigome
{
    public interface IState 
    {
        /* プロパティ */
        public MotigomeController Ctrl { get; set; }

        /* メソッド */
        public void StateEnter();       // 入った瞬間
        public void StateUpdate();      // 更新
        public void StateExit();        // 出た瞬間
    }
}