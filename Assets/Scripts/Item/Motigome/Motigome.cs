using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Motigome {
    public class Motigome : Item {
        [Header("Dropping")]
        [SerializeField] float dropMoveTime;        // ドロップ時間
        [SerializeField] float dropMoveSize;        // ドロップサイズ
        [SerializeField] Ease dropMoveEaseType;     // ドロップイージング

        [Header("Powere")] 
        [SerializeField] float power;
        static int getCount;

        public StateController State { get; private set; }

        public Motigome()
        {
            State = new StateController(this);
        }

        //-------------------------------------------------------------------
        void Awake()
        {
            getCount = 0;

            State.Init(State.Idle);
        }

        void FixedUpdate()
        {
            State.StateUpdate();
        }

        //-------------------------------------------------------------------
        public override void Getted()
        {
            if (State.NowState != State.Drop) {
                getCount++;

                MotiGaugeManager.AddPower(power);
                MotiGaugeVisualizer.Instance.SetDispPower();

                Destroy(gameObject);
            }
        }

        // ドロップされたときの動作
        public void Dropped()
        {
            State.StateTransition(State.Drop);        // 移動状態に遷移
        }

        public void DropMoving()
        {
            var targetPos = 1.5f * Random.insideUnitCircle + (Vector2)transform.position;
            transform.DOMove(targetPos, dropMoveTime)
                        .SetEase(dropMoveEaseType).OnComplete(OnComp);
        }

        void OnComp()
        {
            State.StateTransition(State.Idle);
        }
    }
}