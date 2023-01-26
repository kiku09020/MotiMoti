using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DownMoti {
    public class DownMoti : EnemyBase {
        public Moving Move { get; private set; }

        GameObject target;
        public float TargetDist { get; private set; }   // Player�Ƃ̋���

        protected override void Awake()
        {
            base.Awake();

            Move = GetComponent<Moving>();
            target = GameObject.Find("Moti");
        }

        private void FixedUpdate()
        {
            GetDist();

            Move.MoveUpdate();
        }

        // �����Ƃ̋������擾
        void GetDist()
        {
            if (gameObject && target) {
                TargetDist = Vector2.Distance(target.transform.position, transform.position);
            }
        }
    }
}