using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : IState
{
    /* 値 */
    public Moti Moti { get; set; }

    /* コンポーネント取得用 */


    /* コンストラクタ */
    public NormalState(Moti moti)
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

        // 伸び状態に遷移
        if (Moti.Stretcher.Stretching) {
            state.TransitionState(state.StretchingState);
        }

        // 合体状態に遷移
        else if (Moti.MotiHit.IsMotiTrigger && !Moti.Input.IsTapping) {
            state.TransitionState(state.UnitedState);
		}
    }

    public void StateExit()
    {

    }
}
