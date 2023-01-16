using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    public class StateController:StateControllerBase
    {
        /* プロパティ */
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
    }
}