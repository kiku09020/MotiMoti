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

        /* プロパティ */

        public bool IsMotiTrigger => isMotiTrigger;

        public MotiController OtherMoti => otherMoti;

        /* コンポーネント取得用 */
        MotiController moti;

        //-------------------------------------------------------------------
        private void Awake()
        {
            moti = transform.parent.GetComponent<MotiController>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            // 他のもち
            if (col.gameObject.tag == "Moti") {
                otherMoti = col.gameObject.GetComponent<MotiController>();

                // 大きさが指定数以下だったら合体可能
                if (moti.Family.CheckIfChild(otherMoti)|| moti.Family.Parent == otherMoti) {
                    CheckScaleValue(true);
                }

                else {
                    CheckScaleValue(false);
                }
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

        // 大きさ判定して、フラグを立てる
        void CheckScaleValue(bool isFamily)
        {
            if (isFamily) {
                if (moti.ScaleValue + otherMoti.ScaleValue <= moti.MaxScaleValue) {                     // 他のもちが自分の子のとき
                    isMotiTrigger = true;
                }
            }

            else if (moti.Family.FamilyScaleValue + otherMoti.Family.FamilyScaleValue <= moti.MaxScaleValue) {       // 親子関係以外のもち
                isMotiTrigger = true;
            }

            else {
                isMotiTrigger = false;
            }
        }
    }
}