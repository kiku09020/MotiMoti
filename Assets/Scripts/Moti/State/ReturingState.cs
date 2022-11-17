using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturingState : IState
{
    public Moti Moti { get; set; }

    /* コンストラクタ */
    public ReturingState(Moti moti)
    {
        Moti = moti;
    }

    public void StateEnter()
    {
        // タップ処理
        Moti.Sticker.Tapped();
    }

    public void StateUpdate()
    {
        
    }

    public void StateExit()
    {

    }
}
