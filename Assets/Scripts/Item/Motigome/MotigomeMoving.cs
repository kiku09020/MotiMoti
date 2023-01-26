using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Motigome {
    public class MotigomeMoving : MonoBehaviour {
        GameObject targetObj;

        Tweener moveTween;

        [SerializeField] float moveTime;
        
        private void Awake()
        {
            targetObj = GameObject.Find("Moti");
        }

        public void MoveStart()
        {
            if (targetObj) {
                moveTween = transform.DOMove(targetObj.transform.position, moveTime);
            }
        }

        public void MoveUpdate()
        {
            if (targetObj) {
                moveTween.ChangeEndValue(targetObj.transform.position, moveTime / 2, true);
            }
        }
    }
}