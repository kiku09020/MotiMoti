using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ukimoti {
    public class UkimotiMoving : MonoBehaviour {

        [SerializeField] float moveSpeed;
        Vector2 targetVector;
        Vector2 normalizedTargetVector;

        Ukimoti ukmt;

        private void Awake()
        {
            ukmt = GetComponent<Ukimoti>();
        }

        public void MoveUpdate()
        {
            GetVector();
            Moving();
        }

        // ベクトルを求める
        void GetVector()
        {
            var targetPos = ukmt.Visibilizty.TargetPos;
            targetVector = targetPos - (Vector2)transform.position;
            normalizedTargetVector = targetVector.normalized;
        }

        // 移動
        void Moving()
        {
            transform.position += (Vector3)normalizedTargetVector * moveSpeed;
        }
    }
}