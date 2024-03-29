using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DownMoti {
    public class Moving : MonoBehaviour {
        [SerializeField] float speed;           // 移動速度
        [SerializeField] float movableDist;     // 距離内に入ったら動かす

        DownMoti moti;

        private void Awake()
        {
            moti = GetComponent<DownMoti>();    
        }

        // 移動
        public void MoveUpdate()
        {
            if (moti.TargetDist < movableDist) {
                transform.position += new Vector3(0, -speed, 0);
            }
        }
    }
}