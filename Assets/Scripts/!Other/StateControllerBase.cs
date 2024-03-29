using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateControllerBase : MonoBehaviour
{
    public StateBase NowState{ get; private set; }

//-------------------------------------------------------------------

    // Stateの初期化
    public void StateInit(StateBase state)
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
    public void StateTransition(StateBase nextState)
    {
        NowState.StateExit();
        NowState = nextState;
        NowState.StateEnter();
	}
}
