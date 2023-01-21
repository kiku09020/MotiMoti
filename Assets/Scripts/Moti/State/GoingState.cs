using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    public class GoingState : MotiState
    {
        public override void StateEnter()
        {
            Moti.Ground.ColEnabled = false;

            if (Moti.Family.HasChild) {
                Moti.Stretcher.GoingMove(Moti.Family.OtherMoti);

                // カメラ追尾
                if (!GameManager.isResult) {
                    CameraController.Instance.Chase(Moti.Family.OtherMoti);
                }
            }

            else if (Moti.Family.HasParent) {
                Moti.Stretcher.GoingMove(Moti.Family.OtherMoti);
            }
        }

        public override void StateUpdate()
        {
            base.StateUpdate();

            if (Moti.MotiHit.OtherMoti) {
                Moti.StateCtrl.StateTransition(Moti.StateCtrl.UnitedState);
            }
        }

        public override void StateExit()
        {
            Moti.Ground.ColEnabled = true;
        }

        protected override void CheckHit()
        {
            if (Moti.EnemyHit.IsHit && !GameManager.isResult) {
                CheckHitAction();
            }
        }

        public override void CheckHitAction()
        {
            Moti.EnemyHit.HitEnemy.Killed();        // ドロップ
        }
    }
}