using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ukimoti {
    public class Ukimoti : EnemyBase {
        public StateController State { get; private set; }
        public UkimotiMoving Move { get; private set; }

        //-------------------------------------------------------------------
        protected override void Awake()
        {
            base.Awake();
            State = GetComponent<StateController>();
            Move = GetComponent<UkimotiMoving>();

            State.Init();
            State.StateInit(State.Waiting);
        }

        void FixedUpdate()
        {
            State.NowStateUpate();
        }

        //-------------------------------------------------------------------

    }
}