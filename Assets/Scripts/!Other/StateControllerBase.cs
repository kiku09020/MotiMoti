using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateControllerBase : MonoBehaviour
{
    public IStateBase NowState{ get; private set; }

//-------------------------------------------------------------------

    // State‚Ì‰Šú‰»
    public void StateInit(IStateBase state)
    {
        NowState = state;
        NowState.StateEnter();
	}

    // Œ»İ‚ÌState‚ÌXV
    public void NowStateUpate()
    {
        NowState.StateUpdate();
	}

    // State‚Ì‘JˆÚ
    public void StateTransition(IStateBase nextState)
    {
        NowState.StateExit();
        NowState = nextState;
        NowState.StateEnter();
	}
}
