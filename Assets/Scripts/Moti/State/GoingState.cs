using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    public class GoingState : MonoBehaviour, IState
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

        public void StateUpdate()
        {
            if (Moti.MotiHit.OtherMoti) {
                Moti.StateCtrl.StateTransition(Moti.StateCtrl.UnitedState);
            }

            CheckHit();
        }

        public void StateExit()
        {
            Moti.Ground.ColEnabled = true;
        }

        public void CheckHit()
        {
            if (Moti.EnemyHit.IsHit && !GameManager.isResult) {
                Moti.EnemyHit.HitEnemy.Killed();        // ドロップ
            }
        }
    }
}