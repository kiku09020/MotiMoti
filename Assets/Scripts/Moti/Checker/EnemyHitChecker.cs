using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti {
    public class EnemyHitChecker : HitCheckerTrigger
    {
		public EnemyBase HitEnemy { get; private set; }

		protected override void Awake()
		{
			base.Awake();

			HitEnemy = null;
		}

        protected override void HitEnter(Collider2D collision)
		{
			HitEnemy = collision.GetComponent<EnemyBase>();
		}

		protected override void HitExit(Collider2D collision)
		{
			HitEnemy = null;
		}
	}
}