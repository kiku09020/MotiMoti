using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Motigome {
    public class GroundChecker : MonoBehaviour
    {
        /* 値 */
        bool isGround;

        /* プロパティ */
        public bool IsGround => isGround;

        /* コンポーネント取得用 */



        //-------------------------------------------------------------------
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag == "Stage") {
                isGround = true;
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.tag == "Stage") {
                isGround = false;
            }
        }
    }
}