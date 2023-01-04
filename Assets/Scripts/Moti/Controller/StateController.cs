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
        // 初期状態の指定
        public void InitState(IState state)
        {
            NowState = state;
            NowState.StateEnter();
        }

        // 状態遷移
        public void TransitionState(IState nextState)
        {
            NowState.StateExit();
            NowState = nextState;
            NowState.StateEnter();
        }

        // 現在の処理
        public void NowStateUpdate()
        {
            NowState.StateUpdate();
        }
    }
}