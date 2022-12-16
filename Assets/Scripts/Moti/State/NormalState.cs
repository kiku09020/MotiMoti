using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    public class NormalState : IState
    {
        /* 値 */
        public MotiController Moti { get; set; }

        /* コンポーネント取得用 */


        /* コンストラクタ */
        public NormalState(MotiController moti)
        {
            Moti = moti;
        }

        //-------------------------------------------------------------------
        public void StateEnter()
        {
            
        }

        public void StateUpdate()
        {
            var state = Moti.StateCtrl;
            var child = Moti.Family.Child;

            // 伸び状態に遷移
            if (Moti.Stretcher.IsStretching) {
                state.TransitionState(state.StretchingState);
            }

            // 合体状態に遷移
            else if (Moti.MotiHit.IsMotiTrigger ) {
                state.TransitionState(state.UnitedState);
            }

            else if (child) {
                if (child.Ground.IsGround) {
                    state.TransitionState(state.GoingState);
                }
            }

            else if (Moti.Family.Parent) {
                if (!Moti.Ground.IsGround && !Moti.Family.Parent.Input.IsTapping) {
                    Moti.StateCtrl.TransitionState(state.GoingState);
                }
            }
        }

        public void StateExit()
        {

        }
    }
}