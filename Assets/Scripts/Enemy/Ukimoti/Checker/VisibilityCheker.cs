using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���E�ɓ��������ǂ���
namespace Ukimoti {
    public class VisibilityCheker : HitCheckerTrigger {
        public Vector2 TargetPos { get; private set; }

        List<Collider2D> collisionList = new List<Collider2D>();        // �G�ꂽ���̂̃��X�g

        protected override void HitEnter(Collider2D collision)
        {
            collisionList.Add(collision);       // ���X�g�ɒǉ�
        }

        protected override void HitStay(Collider2D collision)
        {
            var nearlyDist = 10f;

            // �^�[�Q�b�g2������A�߂�����_��
            foreach(var col in collisionList) {
                var targetPos   = col.gameObject.transform.position;
                var vec         = targetPos - transform.position;
                var dist        = vec.magnitude;        // ����

                // ��ԋ߂��̂Ɣ�r���āA�ړI�n���
                if (dist < nearlyDist) {
                    nearlyDist = dist;
                    TargetPos = targetPos;
                }
            }
        }

        protected override void HitExit(Collider2D collision)
        {
            collisionList.Remove(collision);    // ���X�g���珜��
        }
    }
}