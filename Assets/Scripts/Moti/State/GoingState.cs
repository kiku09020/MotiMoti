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
            CameraController.Instance.Chase(Moti.Family.OtherMoti.gameObject);

            if (Moti.Family.HasChild) {
                Moti.Stretcher.GoingMove(Moti.Family.OtherMoti);
            }

            else if (Moti.Family.HasParent) {
                Moti.Stretcher.GoingMove(Moti.Family.OtherMoti);
            }

            // 敵に触れた時
            if (Moti.EnemyHit.IsHit) {
                Destroy(Moti.EnemyHit.HitEnemy);
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
                Moti.EnemyHit.HitEnemy.Killed();
            }
        }
    }
}