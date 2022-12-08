using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Motigome
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class StickChekcer : MonoBehaviour
    {
        /* 値 */
        bool isSticked;

        /* プロパティ */
        public bool IsSticked => isSticked;

        //-------------------------------------------------------------------
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag=="Moti") {
                isSticked = true;
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            
        }
    }
}