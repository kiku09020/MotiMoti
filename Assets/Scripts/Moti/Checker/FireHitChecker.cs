using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti {
    public class FireHitChecker :HitCheckerTrigger
    {
        // ��
        MovingFire.MovingFire hitFire;      // �G�ꂽ��

        //-------------------------------------------------------------------
        public override void Init()
        {
            IsHit = false;
            hitFire = null;
        }

		protected override void HitEnter(Collider2D collision)
		{
            hitFire = collision.gameObject.GetComponent<MovingFire.MovingFire>();
        }

		protected override void HitExit(Collider2D collision)
		{
            hitFire = null;
        }

        // Going��ԂŐG�ꂽ���̏���
        public void GoingFire()
        {
            if (IsHit) {
                Destroy(hitFire.gameObject);
            }
        }

    }
}