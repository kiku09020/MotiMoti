using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Motigome {
    public class MotigomeMoving : MonoBehaviour {
        GameObject targetObj;

        Tweener moveTween;

        [SerializeField] float moveDurationBase;        // ���̈ړ�����
        [SerializeField] float durationRandValue;       // �����_���ɂ���͈�
        float moveDurationRand;                         // �����_���Ȉړ�����

        private void Awake()
        {
            targetObj = GameObject.Find("Moti");
        }

        // �ړ����Ԃ������_���ō쐬
        void SetMoveTime()
        {
            // ���̈ړ����Ԃ��������_���͈͂������Ƃ�
            if (moveDurationBase <= durationRandValue) {
                durationRandValue = moveDurationBase - 0.1f;        // �����_���͈͂����̈ړ����Ԃ�菭�Ȃ�����

                Debug.LogWarning($"<b>{nameof(durationRandValue)}��{nameof(moveDurationBase)}�����傫���ł�</b>");        // �x���\��
            }

            var randValue = durationRandValue * Random.Range(-1.0f, 1.0f);      // �����_���l

            moveDurationRand = moveDurationBase + randValue;                    // ���̈ړ�����+�����_���l
        }

        public void MoveStart()
        {
            if (targetObj) {
                SetMoveTime();
                moveTween = transform.DOMove(targetObj.transform.position, moveDurationRand);
            }
        }

        public void MoveUpdate()
        {
            if (targetObj) {
                moveTween.ChangeEndValue(targetObj.transform.position, moveDurationRand / 2, true);
            }
        }
    }
}