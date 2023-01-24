using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateControllerBase : MonoBehaviour
{
    public StateBase NowState{ get; private set; }

//-------------------------------------------------------------------

    // State�̏�����
    public void StateInit(StateBase state)
    {
        NowState = state;
        NowState.StateEnter();
	}

    // ���݂�State�̍X�V
    public void NowStateUpate()
    {
        NowState.StateUpdate();
	}

    // State�̑J��
    public void StateTransition(StateBase nextState)
    {
        NowState.StateExit();
        NowState = nextState;
        NowState.StateEnter();
	}
}
