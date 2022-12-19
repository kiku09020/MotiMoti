using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    public class GoingState : IState
    {
        public MotiController Moti { get; set; }

        /* コンストラクタ */
        public GoingState(MotiController moti)
        {
            Moti = moti;
        }

        public void StateEnter()
        {
            Moti.Ground.SetEnable(false);

            if (Moti.Family.HasChild) {
                Moti.Stretcher.GoingMove(Moti.Family.OtherMoti);
            }

            else if (Moti.Family.HasParent) {
                Moti.Stretcher.GoingMove(Moti.Family.OtherMoti);
            }
        }

        public void StateUpdate()
        {
            if (Moti.MotiHit.OtherMoti) {
                Moti.StateCtrl.TransitionState(Moti.StateCtrl.UnitedState);
            }
        }

        public void StateExit()
        {

        }
    }
}