using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    public class StateController:StateControllerBase
    {
        /* プロパティ */
        public NormalState NormalState { get; set; }
        public StretchingState StretchingState { get; set; }
        public UnitingState UnitedState { get; set; }
        public GoingState GoingState { get; set; }

        // コンストラクタ
        private void Awake()
        {
            NormalState = gameObject.AddComponent<NormalState>();
            StretchingState = gameObject.AddComponent<StretchingState>();
            UnitedState = gameObject.AddComponent<UnitingState>();
            GoingState = gameObject.AddComponent<GoingState>();
        }

        //-------------------------------------------------------------------
    }
}