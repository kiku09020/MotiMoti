using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    [RequireComponent(typeof(Collider2D))]
    public class GroundHitChecker : HitCheckerCollision{
        /* 値 */
        MotiController moti;

        Vector2 hitPoint;           // 触れたところの位置

        /* プロパティ */
        public Vector2 HitPoint => hitPoint;

		//-------------------------------------------------------------------
		protected override void Awake()
		{
			base.Awake();

            moti = transform.parent.GetComponent<MotiController>();
		}

		public void Init()
        {
            IsHit = false;
            hitPoint = transform.parent.position;

            _collider.enabled = true;
        }

        //-------------------------------------------------------------------
        protected override void HitEnter(Collision2D collision)
        {
            foreach(var contact in collision.contacts) {
                hitPoint = contact.point;
            }

            // 演出
            moti.Particle.Play(ParticleNames_Moti.ground, moti.Ground.HitPoint);
            SE.Instance.Play("hit");
        }

		protected override void HitExit(Collision2D collision)
		{
            hitPoint = transform.parent.position;
        }
    }
}