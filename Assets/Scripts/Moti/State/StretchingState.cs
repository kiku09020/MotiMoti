using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti {
    public class StretchingState : IState
    {
        /* 値 */
        public MotiController Moti { get; set; }

        /* コンポーネント取得用 */

        /* コンストラクタ */
        public StretchingState(MotiController moti)
        {
            Moti = moti;
        }

        //-------------------------------------------------------------------
        public void StateEnter()
        {
           
        }

        public void StateUpdate()
        {
            StateController state = Moti.StateCtrl;

            // 通常状態に繊維
            if (!Moti.Stretcher.IsStretching) {
                state.StateTransition(state.NormalState);
            }

            CheckHit();
        }

        public void StateExit()
        {
            
        }

        //-------------------------------------------------------------------
        public void CheckHit()
        {
            if (Moti.EnemyHit.IsHit) {
                Moti.StateCtrl.StateTransition(Moti.StateCtrl.GoingState);
                GameManager.isResult = true;
            }
        }
    }
}