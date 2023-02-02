using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Motigome {
    public class MotigomeMoving : MonoBehaviour {
        GameObject targetObj;

        Tweener moveTween;

        [SerializeField] float moveDurationBase;        // 元の移動時間
        [SerializeField] float durationRandValue;       // ランダムにする範囲
        float moveDurationRand;                         // ランダムな移動時間

        private void Awake()
        {
            targetObj = GameObject.Find("Moti");
        }

        // 移動時間をランダムで作成
        void SetMoveTime()
        {
            // 元の移動時間よりもランダム範囲が多いとき
            if (moveDurationBase <= durationRandValue) {
                durationRandValue = moveDurationBase - 0.1f;        // ランダム範囲を元の移動時間より少なくする

                Debug.LogWarning($"<b>{nameof(durationRandValue)}が{nameof(moveDurationBase)}よりも大きいです</b>");        // 警告表示
            }

            var randValue = durationRandValue * Random.Range(-1.0f, 1.0f);      // ランダム値

            moveDurationRand = moveDurationBase + randValue;                    // 元の移動時間+ランダム値
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