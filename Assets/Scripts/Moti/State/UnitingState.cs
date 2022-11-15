using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitingState : IState
{
    /* 値 */
    public Moti Moti { get; set; }

    /* コンポーネント取得用 */

    /* コンストラクタ */
    public UnitingState(Moti moti)
    {
        Moti = moti;
    }

    //-------------------------------------------------------------------
    public void StateEnter()
    {
        
    }

    public void StateUpdate()
    {
        Moti.Uniter.CheckUnitable();

		if (Moti.Uniter.IsUnitable) {
            Moti.StateCtrl.TransitionState(Moti.StateCtrl.NormalState);     // 通常状態へ
        }
    }

    public void StateExit()
    {
        Moti.Uniter.Unite();                                            // 合体
    }

    //-------------------------------------------------------------------

}
