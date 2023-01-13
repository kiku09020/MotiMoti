using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Motigome {
    public class MotigomeMoving : MonoBehaviour {
        GameObject targetObj;

        Tweener moveTween;
        
        private void Awake()
        {
            targetObj = GameObject.Find("Moti");
        }

        public void MoveStart()
        {
            if (targetObj) {
                moveTween = transform.DOMove(targetObj.transform.position, 5);
            }
        }

        public void MoveUpdate()
        {
            if (targetObj) {
                moveTween.ChangeEndValue(targetObj.transform.position, 0.5f , true);
            }
        }
    }
}