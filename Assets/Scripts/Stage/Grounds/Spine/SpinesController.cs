using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spines {
    public class SpinesController : MonoBehaviour {

        [SerializeField] float waitTimeLimit;
        float waitTimer;

        public bool IsActive { get; set; }

        /* プロパティ */
        public StateController State { get; private set; }
        public SpinesAttacking Attacking { get; private set; }

        //-------------------------------------------------------------------
        void Awake()
        {
            State = GetComponent<StateController>();
            Attacking = GetComponent<SpinesAttacking>();

            State.StateInit(State.Waiting);
        }

        void FixedUpdate()
        {
            State.NowStateUpate();
        }

        //-------------------------------------------------------------------
        // 待機
        public void Wait()
        {
            waitTimer += Time.deltaTime;

            if (waitTimer > waitTimeLimit) {
                waitTimer = 0;
                State.StateTransition(State.Attacking);
            }
        }
    }
}