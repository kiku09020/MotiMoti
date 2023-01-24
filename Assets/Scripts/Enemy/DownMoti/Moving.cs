using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DownMoti {
    public class Moving : MonoBehaviour {
        [SerializeField] float speed;           // �ړ����x
        [SerializeField] float movableDist;     // �������ɓ������瓮����

        DownMoti moti;

        private void Awake()
        {
            moti = GetComponent<DownMoti>();    
        }

        // �ړ�
        public void MoveUpdate()
        {
            if (moti.TargetDist < movableDist) {
                transform.position += new Vector3(0, -speed, 0);
            }
        }
    }
}