using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Motigome {
    public class StateController  {

        public IState NowState { get; private set; }

        public IdlingState Idle{ get; }
        public MovingState Moving { get; }

        public StateController(Motigome motigome)
        {
            Idle = new IdlingState(motigome);
            Moving = new MovingState(motigome);
        }

        //-------------------------------------------------------------------
        public void Init(IState state)
        {
            NowState = state;
            NowState.StateEnter();
        }

        public void StateTransition(IState nextState)
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
}