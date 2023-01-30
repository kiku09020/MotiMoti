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

        [Header("Power")] 
        [SerializeField] float power;
        static int getCount;

        // Renderer
        Renderer rend;

        public StateController State { get; private set; }
        public MotigomeMoving Moving { get; private set; }

        //-------------------------------------------------------------------
        void Awake()
        {
            State = gameObject.AddComponent<StateController>();
            Moving = GetComponent<MotigomeMoving>();

            rend = GetComponent<Renderer>();

            var rand = Random.Range(0, 2f);
            rend.material.SetFloat("_speed", rand);

            getCount = 0;
            State.StateInit(State.Drop);
        }

        void FixedUpdate()
        {
            State.NowStateUpate();
        }

        //-------------------------------------------------------------------
        public override void Getted()
        {
            if (State.NowState != State.Drop) {
                getCount++;

                MotiGaugeManager.Instance.AddPower(power);

                var rand = Random.Range(0.5f, 1.5f);

                SE.Instance.Play("motigome", 0, 0.5f, rand);

                Destroy(gameObject);
            }
        }

        //-------------------------------------------------------------------
        // ドロップされたときの動作
        public void Dropped()
        {
            State.StateTransition(State.Drop);        // 移動状態に遷移
        }

        public void DropMoving()
        {
            if (gameObject) {

                var targetPos = 1.5f * Random.insideUnitCircle + (Vector2)transform.position;
                transform.DOMove(targetPos, dropMoveTime)
                            .SetEase(dropMoveEaseType).OnComplete(OnComp);
            }
        }

        void OnComp()
        {
            State.StateTransition(State.Moving);
        }
    }
}