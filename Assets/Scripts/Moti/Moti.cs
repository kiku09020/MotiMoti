using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moti : MonoBehaviour
{
    /* 値 */


    /* フラグ */


    /* プロパティ */


    /* コンポーネント取得用 */
    Rigidbody2D rb;


//-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */


        /* コンポーネント取得 */
        rb = GetComponent<Rigidbody2D>();

        /* 初期化 */
        
    }

    void Update()
    {
		if (Input.anyKeyDown) {
            rb.AddForce(Vector2.up * 800);
		}
    }

//-------------------------------------------------------------------

}
