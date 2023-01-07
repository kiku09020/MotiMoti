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
            var child = Moti.Family.OtherMoti;

            // 伸び状態に遷移
            if (Moti.Stretcher.IsStretching) {
                state.TransitionState(state.StretchingState);
            }

            // 合体状態に遷移
            else if (Moti.MotiHit.IsMotiTrigger && Moti.Family.HasChild ) {
                state.TransitionState(state.UnitedState);
            }

            // 移動状態(親→子　地上)
            else if (Moti.Family.HasChild) {
                if (Moti.Ground.IsGround && child.Ground.IsGround) {
                    state.TransitionState(state.GoingState);
                }
            }

            // 移動状態(子→親　空中)
            else if (Moti.Family.HasParent) {
                if (!Moti.Ground.IsGround && !Moti.Family.OtherMoti.Input.IsTapping) {
                    Moti.StateCtrl.TransitionState(state.GoingState);
                }
            }

            CheckHitFire();
        }

        public void StateExit()
        {

        }

        public void CheckHitFire()
        {
            if (Moti.FireHit.IsHitFire) {
                GameManager.isResult = true;
            }
        }
    }
}