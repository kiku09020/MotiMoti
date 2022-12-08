using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Motigome
{
    public class NormalState : IState
    {
        /* プロパティ */
        public MotigomeController Ctrl { get; set; }

        /* コンストラクタ */
        public NormalState(MotigomeController ctrl)
        {
            Ctrl = ctrl;
        }

        /* メソッド */
        public void StateEnter()
        {

        }

        public void StateUpdate()
        {
            Ctrl.Jump();        // ジャンプ

            var state = Ctrl.StateCtrl;

            // くっつき状態へ遷移
            if (Ctrl.Stick.IsSticked) {
                state.TransitionState(state.Sticked);
            }
        }

        public void StateExit()
        {

        }
    }
}