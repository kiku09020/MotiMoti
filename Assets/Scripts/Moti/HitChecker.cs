using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitChecker : MonoBehaviour
{
    /* 値 */
    bool isGround;      // 着地しているか

    /* プロパティ */
    public bool IsGround => isGround;

    /* コンポーネント取得用 */



//-------------------------------------------------------------------
    void Awake()
    {
        /* オブジェクト取得 */ 


        /* コンポーネント取得 */     


        /* 初期化 */
        
    }

    void FixedUpdate()
    {
        
    }

    //-------------------------------------------------------------------
    private void OnTriggerEnter2D(Collider2D col)
    {
        // 着地時
        if (col.gameObject.tag == "Stage") {
            isGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        // 離れるとき
        if (col.gameObject.tag == "Stage") {
            isGround = false;
        }
    }
}
