using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    public abstract class MotiState:StateBase
    {
        /* プロパティ */
        public MotiController Moti { get; protected set; }      // コンポーネント参照用

        public override void StateUpdate()
        {
            CheckHit();
        }

        // 触れたかどうか
        protected void CheckHit()
        {
            if (Moti.EnemyHit.IsHit && !GameManager.isResult) {
                if (!MotiPowerUp.IsPowerUp) {
                    CheckHitAction();
                }
            }
        }

        // 触れた時の処理
        public virtual void CheckHitAction()
        {
            GameManager.isResult = true;
        }

        private void Awake()
        {
            Moti = GetComponent<MotiController>();
        }
    }
}