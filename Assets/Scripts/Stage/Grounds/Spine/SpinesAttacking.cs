using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Spines {
    public class SpinesAttacking : MonoBehaviour {
        [Header("Attack")]
        [SerializeField] float attackTime;
        [SerializeField] float attackTargetSize;

        [Header("Wait")]
        [SerializeField] float waitTimeLimit;
        float timer;

        Vector2 startSize;

        SpinesController spine;

        //-------------------------------------------------------------------
        void Awake()
        {
            spine = GetComponent<SpinesController>();

            startSize = transform.localScale;
        }

        //-------------------------------------------------------------------
        // �Ƃ��o��
        public void Attack()
        {
            transform.DOScaleY(attackTargetSize, attackTime);
        }

        // �Ƃ��߂�
        public void RetrunAttack()
        {
            transform.DOScaleY(startSize.y, attackTime)
                .OnComplete(() => spine.State.StateTransition(spine.State.Waiting));
        }

        // �Ƃ��o����Ԃ̑ҋ@
        public void AttackWait()
        {
            timer += Time.deltaTime;

            if (timer > waitTimeLimit) {
                timer = 0;

                RetrunAttack();
            }
        }

    }
}