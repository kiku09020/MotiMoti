using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ukimoti {
    public class Ukimoti : EnemyBase {
        public StateController State { get; private set; }
        public UkimotiMoving Move { get; private set; }
        public VisibilityCheker Visibilizty { get; private set; }

        //-------------------------------------------------------------------
        protected override void Awake()
        {
            base.Awake();
            State = GetComponent<StateController>();
            Move = GetComponent<UkimotiMoving>();
            Visibilizty = GetComponentInChildren(typeof(VisibilityCheker)) as VisibilityCheker;

            State.Init();
            State.StateInit(State.Idle);
        }

        void FixedUpdate()
        {
            // Ž‹ŠE‚É“ü‚Á‚Ä‚¢‚½‚çˆÚ“®
            if (Visibilizty.IsHit) {
                Move.MoveUpdate();
            }

            State.NowStateUpate();
        }

        //-------------------------------------------------------------------

    }
}