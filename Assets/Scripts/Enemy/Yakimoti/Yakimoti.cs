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
        [SerializeField] float movableRangeX;       // X軸の可動範囲
        [SerializeField] Ease moveEaseType;         // 移動イージング
        Vector2 targetPos;                          // 目標座標
        float xDir;                                 // 進行方向

        [Header("Wait")]
        [SerializeField] float waitTime;            // 待機時間
        float waitTimer;

        StateController state;

        //-------------------------------------------------------------------
        protected override void Awake()
        {
            base.Awake();

            xDir = Expansion.GetRandomDirect();     // 方向ランダムにする
            SetMoveTime();

            state = new StateController(this);
            state.StateInit(state.Waiting);
        }

        void FixedUpdate()
        {
            state.NowStateUpate();
        }

        //-------------------------------------------------------------------
        // 目標座標を指定
        public void SetTarget()
		{
            xDir *= -1;     // 方向指定
            var w = transform.localScale.x;
            var x = (movableRangeX * xDir) + ((w / 2) * -xDir);
            targetPos = new Vector2(x, transform.position.y);
		}

        // 移動時間の指定
        public void SetMoveTime()
		{
            moveTime = Random.Range(minMoveTime, maxMoveTime);
		}

        // 移動
        public void Move()
		{
            transform.DOMove(targetPos, moveTime)
                .SetEase(moveEaseType)
                .OnComplete(OnComp);
		}

        void OnComp()
		{
            state.StateTransition(state.Waiting);       // 移動完了時に、待機状態に遷移
		}

        // 待機
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