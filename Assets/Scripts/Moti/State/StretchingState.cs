using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchingState : IState
{
    /* 値 */
    public Moti Moti { get; set; }

    /* コンポーネント取得用 */

    /* コンストラクタ */
    public StretchingState(Moti moti)
    {
        Moti = moti;
    }

    //-------------------------------------------------------------------
    public void StateEnter()
    {
        
    }

    public void StateUpdate()
    {
        MotiStateController state = Moti.StateCtrl;

		if (!Moti.Stretcher.IsStretching) {
            state.TransitionState(state.NormalState);
		}
    }

    public void StateExit()
    {

    }

    //-------------------------------------------------------------------

}
