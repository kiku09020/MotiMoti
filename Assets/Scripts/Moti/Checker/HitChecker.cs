using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitChecker : MonoBehaviour
{
    /* 値 */
    bool isMotiTrigger;         // 範囲内に他のもちがいるか

    Moti otherMoti;

    /* プロパティ */

    public bool IsMotiTrigger => isMotiTrigger;

    public Moti OtherMoti => otherMoti;

    /* コンポーネント取得用 */
    Moti moti;

    //-------------------------------------------------------------------
    private void Awake()
    {
        moti = transform.parent.GetComponent<Moti>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // 他のもち
		if (col.gameObject.tag == "Moti") {
            isMotiTrigger = true;
            otherMoti = col.gameObject.GetComponent<Moti>();
		}
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        // 他のもち
        if (col.gameObject.tag == "Moti") {
            isMotiTrigger = false;
        }
    }
}
