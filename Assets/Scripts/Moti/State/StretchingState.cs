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
            MotiStateController state = Moti.StateCtrl;

            // 通常状態に繊維
            if (!Moti.Stretcher.IsStretching) {
                state.TransitionState(state.NormalState);
            }
        }

        public void StateExit()
        {
            Moti.RB.gravityScale = 1;               // 終了時に重力有効化
        }

        //-------------------------------------------------------------------

    }
}