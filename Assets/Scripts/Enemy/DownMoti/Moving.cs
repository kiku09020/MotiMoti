using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DownMoti {
    public class Moving : MonoBehaviour {
        [SerializeField] float speed;           // ˆÚ“®‘¬“x
        [SerializeField] float movableDist;     // ‹——£“à‚É“ü‚Á‚½‚ç“®‚©‚·

        DownMoti moti;

        private void Awake()
        {
            moti = GetComponent<DownMoti>();    
        }

        // ˆÚ“®
        public void MoveUpdate()
        {
            if (moti.TargetDist < movableDist) {
                transform.position += new Vector3(0, -speed, 0);
            }
        }
    }
}