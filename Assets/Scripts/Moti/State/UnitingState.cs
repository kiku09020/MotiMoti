using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    public class UnitingState : IState
    {
        /* 値 */
        public MotiController Moti { get; set; }

        /* コンポーネント取得用 */

        /* コンストラクタ */
        public UnitingState(MotiController moti)
        {
            Moti = moti;
        }

        //-------------------------------------------------------------------
        public void StateEnter()
        {
            Moti.StateCtrl.StateTransition(Moti.StateCtrl.NormalState);     // 通常状態へ
        }

        public void StateUpdate()
        {
            CheckHit();
        }

        public void StateExit()
        {
            Moti.Uniter.Unite();                                            // 合体
        }

        //-------------------------------------------------------------------
        public void CheckHit()
        {
            if (Moti.FireHit.IsHit) {
                GameManager.isResult = true;
            }

            if (Moti.EnemyHit.IsHit) {
                GameManager.isResult = true;
            }
        }
    }
}