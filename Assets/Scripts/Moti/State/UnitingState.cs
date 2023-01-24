using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    public class UnitingState : MotiState
    {
        //-------------------------------------------------------------------
        public override void StateEnter()
        {
            Moti.StateCtrl.StateTransition(Moti.StateCtrl.NormalState);     // 通常状態へ
        }

        public override void StateUpdate()
        {
            base.StateUpdate();
        }

        public override void StateExit()
        {
            Moti.Uniter.Unite();                                            // 合体
            FireController.Instance.UnitedMove(Moti);
        }

        //-------------------------------------------------------------------
    }
}