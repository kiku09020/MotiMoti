using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    [RequireComponent(typeof(Collider2D))]
    public class HitChecker : MonoBehaviour
    {
        /* 値 */
        bool isMotiTrigger;         // 範囲内に他のもちがいるか
        MotiController otherMoti;

        [SerializeField] MotiController moti;

        /* プロパティ */
        public bool IsMotiTrigger => isMotiTrigger;
        public MotiController OtherMoti => otherMoti;

        //-------------------------------------------------------------------
        private void OnTriggerEnter2D(Collider2D col)
        {
			switch (col.gameObject.tag) {
                case "Moti":
                    otherMoti = col.gameObject.GetComponent<MotiController>();
                    isMotiTrigger = true;
                    break;

                case "Fire":
					if (moti.StateCtrl.NowState != moti.StateCtrl.GoingState) {

					}
                    GameManager.isResult = true;
                    break;
			}
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            // 他のもち
            if (col.gameObject.tag == "Moti") {
                isMotiTrigger = false;
                otherMoti = null;
            }
        }

        // リセット
        public void InitValues()
        {
            isMotiTrigger = false;
            otherMoti = null;
        }
    }
}