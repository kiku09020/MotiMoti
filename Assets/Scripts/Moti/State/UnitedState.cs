using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitedState : IState
{
    /* 値 */
    public Moti Moti { get; set; }

    /* コンポーネント取得用 */

    /* コンストラクタ */
    public UnitedState(Moti moti)
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

    //-------------------------------------------------------------------

}
