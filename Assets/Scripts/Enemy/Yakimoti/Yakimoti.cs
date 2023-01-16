using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Yakimoti {
    public class Yakimoti : EnemyBase {
        [Header("moveTime")]
        [SerializeField] float minMoveTime;
        [SerializeField] float maxMoveTime;
        float moveTime;

        [Header("Move")]
        [SerializeField] float movableRangeX;       // X���̉��͈�
        [SerializeField] Ease moveEaseType;         // �ړ��C�[�W���O
        Vector2 targetPos;                          // �ڕW���W
        float xDir;                                 // �i�s����

        [Header("Wait")]
        [SerializeField] float waitTime;            // �ҋ@����
        float waitTimer;

        StateController state;

        //-------------------------------------------------------------------
        protected override void Awake()
        {
            base.Awake();

            xDir = Expansion.GetRandomDirect();     // ���������_���ɂ���
            SetMoveTime();

            state = new StateController(this);
            state.StateInit(state.Waiting);
        }

        void FixedUpdate()
        {
            state.NowStateUpate();
        }

        //-------------------------------------------------------------------
        // �ڕW���W���w��
        public void SetTarget()
		{
            xDir *= -1;     // �����w��
            var w = transform.localScale.x;
            var x = (movableRangeX * xDir) + ((w / 2) * -xDir);
            targetPos = new Vector2(x, transform.position.y);
		}

        // �ړ����Ԃ̎w��
        public void SetMoveTime()
		{
            moveTime = Random.Range(minMoveTime, maxMoveTime);
		}

        // �ړ�
        public void Move()
		{
            transform.DOMove(targetPos, moveTime)
                .SetEase(moveEaseType)
                .OnComplete(OnComp);
		}

        void OnComp()
		{
            state.StateTransition(state.Waiting);       // �ړ��������ɁA�ҋ@��ԂɑJ��
		}

        // �ҋ@
        public void WaitTimer()
		{
            waitTimer += Time.deltaTime;

			if (waitTimer > waitTime) {
                waitTimer = 0;
                state.StateTransition(state.Moving);
			}
		}
    }
}