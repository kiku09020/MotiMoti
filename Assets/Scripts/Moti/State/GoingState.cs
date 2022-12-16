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

            if (Moti.Family.Child) {
                Moti.Stretcher.GoingMove(Moti.Family.Child);
            }

            else if (Moti.Family.Parent) {
                Moti.Stretcher.GoingMove(Moti.Family.Parent);
            }
        }

        public void StateUpdate()
        {

        }

        public void StateExit()
        {

        }
    }
}