using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DownMoti {
    public class DownMoti : EnemyBase {
        public Moving Move { get; private set; }

        GameObject target;
        public float TargetDist { get; private set; }   // Player‚Æ‚Ì‹——£

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

        // ‚à‚¿‚Æ‚Ì‹——£‚ðŽæ“¾
        void GetDist()
        {
            if (gameObject && target) {
                TargetDist = Vector2.Distance(target.transform.position, transform.position);
            }
        }
    }
}