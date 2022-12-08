using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    public class ReturingState : IState
    {
        public MotiController Moti { get; set; }

        /* コンストラクタ */
        public ReturingState(MotiController moti)
        {
            Moti = moti;
        }

        public void StateEnter()
        {
            // タップ処理
            Moti.Sticker.Tapped();
        }

        public void StateUpdate()
        {
            if (!Moti.Input.IsInTapped) {
                Moti.StateCtrl.TransitionState(Moti.StateCtrl.NormalState);
            }
        }

        public void StateExit()
        {

        }
    }
}