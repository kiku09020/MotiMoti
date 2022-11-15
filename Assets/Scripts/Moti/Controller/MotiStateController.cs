using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotiStateController
{
    /* 値 */


    /* コンポーネント取得用 */
    NormalState normal;
    StretchingState stretching;
    UnitingState united;

    /* プロパティ */
    public IState NowState { get; private set; }

    public NormalState NormalState => normal;
    public StretchingState StretchingState => stretching;
    public UnitingState UnitedState => united;

    // コンストラクタ
    public MotiStateController(Moti moti)
    {
        normal = new NormalState(moti);
        stretching = new StretchingState(moti);
        united = new UnitingState(moti);
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

        Debug.Log("<color=yellow>"+NowState+"</color>");
    }
}
