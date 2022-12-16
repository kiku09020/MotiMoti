using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    public class MotiStateController
    {
        /* 値 */
        MotiController moti;

        /* コンポーネント取得用 */
        NormalState normal;
        StretchingState stretching;
        UnitingState united;
        GoingState going;

        /* プロパティ */
        public IState NowState { get; private set; }

        public NormalState NormalState => normal;
        public StretchingState StretchingState => stretching;
        public UnitingState UnitedState => united;
        public GoingState GoingState => going;

        // コンストラクタ
        public MotiStateController(MotiController moti)
        {
            this.moti = moti;

            normal = new NormalState(moti);
            stretching = new StretchingState(moti);
            united = new UnitingState(moti);
            going = new GoingState(moti);
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

            Debug.Log("<color=yellow>" + NowState + "</color>",moti.gameObject);
        }
    }
}