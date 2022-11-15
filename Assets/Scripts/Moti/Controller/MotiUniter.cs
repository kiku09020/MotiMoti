using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* もちを合体させる処理 */
public class MotiUniter : MonoBehaviour
{
    /* 値 */
    bool isUnitable;        // 合体可能か

    /* プロパティ */
    public bool IsUnitable => isUnitable;

    /* コンポーネント取得用 */
    Moti moti;


//-------------------------------------------------------------------
    void Awake()
    {
        /* オブジェクト取得 */


        /* コンポーネント取得 */
        moti = GetComponent<Moti>();

        /* 初期化 */
        
    }

    //-------------------------------------------------------------------
    public void Unite()
    {
        HitChecker hit = moti.MotiHit;

        transform.localScale += hit.OtherMoti.transform.localScale;
        Destroy(hit.OtherMoti.gameObject);
    }

    // 合体可能かを調べる
    public void CheckUnitable()
	{
        HitChecker hit = moti.MotiHit;

        if (hit.IsMotiTrigger) {     // 近くに他のもちがいるとき
            isUnitable = true;
        }

        else {
            isUnitable = false;
        }
	}
}
