using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Motigome
{
    public class StateController
    {
        /* プロパティ */
        public IState NowState { get; private set; }

        public NormalState Normal => normal;
        public StickedState Sticked => sticked;

        /* コンポーネント取得用 */
        NormalState normal;
        StickedState sticked;

        //-------------------------------------------------------------------
        /* コンストラクタ */
        public StateController(MotigomeController ctrler)
        {
            normal = new NormalState(ctrler);
            sticked = new StickedState(ctrler);
        }

        // 状態の初期化
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

        // 状態ごとの更新処理
        public void StateUpdate()
        {
            NowState.StateUpdate();
        }

    }
}