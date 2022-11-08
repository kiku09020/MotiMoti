using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : IState
{
    /* 値 */
    public Moti Moti { get; set; }

    /* コンポーネント取得用 */


    /* コンストラクタ */
    public NormalState(Moti moti)
    {
        Moti = moti;
	}

//-------------------------------------------------------------------
    public void StateEnter()
    {

    }

    public void StateUpdate()
    {

    }

    public void StateExit()
    {

    }
}
