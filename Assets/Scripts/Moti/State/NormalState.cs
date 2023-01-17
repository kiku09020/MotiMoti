using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    public class NormalState : MotiState
    {
        //-------------------------------------------------------------------
        public override void StateEnter()
        {
            
        }

        public override void StateUpdate()
        {
            var state = Moti.StateCtrl;
            var child = Moti.Family.OtherMoti;

            // 伸び状態に遷移
            if (Moti.Stretcher.IsStretching) {
                state.StateTransition(state.StretchingState);
            }

            // 合体状態に遷移
            else if (Moti.MotiHit.IsHit && Moti.Family.HasChild ) {
                state.StateTransition(state.UnitedState);
            }

            // 移動状態(親→子　地上)
            else if (Moti.Family.HasChild) {
                if (Moti.Ground.IsHit && child.Ground.IsHit) {
                    state.StateTransition(state.GoingState);
                }
            }

            // 移動状態(子→親　空中)
            else if (Moti.Family.HasParent) {
                if (!Moti.Ground.IsHit && !InputChecker.IsTapping) {
                    Moti.StateCtrl.StateTransition(state.GoingState);
                }
            }

            CheckHit();
        }

        public override void StateExit()
        {

        }

        public override void CheckHit()
        {
            if (Moti.EnemyHit.IsHit) {
                GameManager.isResult = true;
            }
        }
    }
}