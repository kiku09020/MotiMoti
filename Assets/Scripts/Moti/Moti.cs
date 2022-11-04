using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moti : MonoBehaviour
{
    /* 値 */
    [Header("スクリプト")]
    [SerializeField] HitChecker hit;

    [Header("値")]
    [SerializeField] float jumpForce;

    /* フラグ */

    /* コンポーネント取得用 */

    Rigidbody2D rb;

//-------------------------------------------------------------------
    void Start()
    {
        /* コンポーネント取得 */
        rb = GetComponent<Rigidbody2D>();

        /* 初期化 */
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && hit.IsGround) {
            rb.AddForce(Vector2.up * jumpForce);
		}

        rb.AddForce(Vector2.right * Input.GetAxis("Horizontal") * 0.5f);
    }

    //-------------------------------------------------------------------
}
