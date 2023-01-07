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
            Moti.Ground.ColEnabled = false;
            CameraController.Instance.ChaseObject(Moti.Family.OtherMoti.gameObject);

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

            CheckHitFire();
        }

        public void StateExit()
        {
            Moti.Ground.ColEnabled = true;
        }

        public void CheckHitFire()
        {
            Moti.FireHit.GoingFire();
        }
    }
}