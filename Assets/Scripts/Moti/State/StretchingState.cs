using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti {
    public class StretchingState : MotiState
    {
        //-------------------------------------------------------------------
        public override void StateEnter()
        {
           
        }

        public override void StateUpdate()
        {
            base.StateUpdate();

            StateController state = Moti.StateCtrl;

            // 通常状態に繊維
            if (!Moti.Stretcher.IsStretching) {
                state.StateTransition(state.NormalState);
            }
        }

        public override void StateExit()
        {
            
        }

        //-------------------------------------------------------------------
        public override void CheckHitAction()
        {
            base.CheckHitAction();

            //Moti.StateCtrl.StateTransition(Moti.StateCtrl.GoingState);
        }
    }
}