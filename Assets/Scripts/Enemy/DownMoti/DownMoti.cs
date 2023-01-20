using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DownMoti {
    public class DownMoti : EnemyBase {
        public Moving Move { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            Move = GetComponent<Moving>();
        }

        private void FixedUpdate()
        {
            GetDist();

            Move.MoveUpdate();
        }
    }
}