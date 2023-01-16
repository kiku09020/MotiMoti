using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateControllerBase : MonoBehaviour
{
    public IStateBase NowState{ get; private set; }

//-------------------------------------------------------------------

    // Stateの初期化
    public void StateInit(IStateBase state)
    {
        NowState = state;
        NowState.StateEnter();
	}

    // 現在のStateの更新
    public void NowStateUpate()
    {
        NowState.StateUpdate();
	}

    // Stateの遷移
    public void StateTransition(IStateBase nextState)
    {
        NowState.StateExit();
        NowState = nextState;
        NowState.StateEnter();
	}
}
