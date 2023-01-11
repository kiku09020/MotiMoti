using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateControllerBase : MonoBehaviour
{
    public IStateBase NowState { get; protected set; }

//-------------------------------------------------------------------
    public void Init(IStateBase state)
    {
        NowState = state;
        NowState.StateEnter();
    }

    public void StateTransition(IStateBase nextState)
    {
        NowState.StateExit();
        NowState = nextState;
        NowState.StateEnter();
    }

    public void StateUpdate()
    {
        NowState.StateUpdate();
    }
}
