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
            Moti.Ground.SetEnable(true);
            Moti.StateCtrl.TransitionState(Moti.StateCtrl.NormalState);     // 通常状態へ
        }

        public void StateUpdate()
        {
            
        }

        public void StateExit()
        {
            Moti.Uniter.Unite();                                            // 合体
        }

        //-------------------------------------------------------------------

    }
}