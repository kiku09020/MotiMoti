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
        // とげ出る
        public void Attack()
        {
            transform.DOScaleY(attackTargetSize, attackTime);
        }

        // とげ戻る
        public void RetrunAttack()
        {
            transform.DOScaleY(startSize.y, attackTime)
                .OnComplete(() => spine.State.StateTransition(spine.State.Waiting));
        }

        // とげ出た状態の待機
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