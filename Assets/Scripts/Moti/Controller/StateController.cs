using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    public class StateController
    {
        /* プロパティ */
        public IState NowState { get; private set; }

        public NormalState NormalState { get; }
        public StretchingState StretchingState { get; }
        public UnitingState UnitedState { get; }
        public GoingState GoingState { get; }

        // コンストラクタ
        public StateController(MotiController moti)
        {
            NormalState = new NormalState(moti);
            StretchingState = new StretchingState(moti);
            UnitedState = new UnitingState(moti);
            GoingState = new GoingState(moti);
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