using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Motigome {
    public class Motigome : Item {
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
        protected override void Getted()
        {
            getCount++;

            MotiGaugeManager.AddPower(power);
            MotiGaugeVisualizer.Instance.SetDispPower();

            Destroy(gameObject);
        }

        // ÉhÉçÉbÉvÇ≥ÇÍÇΩÇ∆Ç´ÇÃìÆçÏ
        public void Dropped()
        {
            
        }

        protected override void OnTriggerEnter2D(Collider2D col)
        {
            base.OnTriggerEnter2D(col);
        }
    }
}