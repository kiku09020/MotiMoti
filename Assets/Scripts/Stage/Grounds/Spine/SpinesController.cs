using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spines {
    public class SpinesController : MonoBehaviour {

        [SerializeField] float waitTimeLimit;
        float waitTimer;

        public bool IsActive { get; set; }

        Collider2D col;

        /* �v���p�e�B */
        public StateController State { get; private set; }
        public SpinesAttacking Attacking { get; private set; }

        public bool ColEnabled { get => col.enabled; private set => col.enabled = value; }      // �����蔻��̗L��
        //-------------------------------------------------------------------
        void Awake()
        {
            State = GetComponent<StateController>();
            Attacking = GetComponent<SpinesAttacking>();
            col = GetComponent<Collider2D>();

            State.Init();
            State.StateInit(State.Waiting);
        }

        void FixedUpdate()
        {
            State.NowStateUpate();

            CheckCollisionEnable();
        }

        //-------------------------------------------------------------------
        // �ҋ@
        public void Wait()
        {
            waitTimer += Time.deltaTime;

            if (waitTimer > waitTimeLimit) {
                waitTimer = 0;
                State.StateTransition(State.Attacking);
            }
        }

        // IsActivate��enable
        void CheckCollisionEnable()
        {
            ColEnabled = IsActive;
        }
    }
}