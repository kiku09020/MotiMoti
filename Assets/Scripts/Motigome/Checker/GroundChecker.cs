using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Motigome {

    [RequireComponent(typeof(BoxCollider2D))]
    public class GroundChecker : MonoBehaviour
    {
        /* 値 */
        bool isGround;

        /* プロパティ */
        public bool IsGround => isGround;

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