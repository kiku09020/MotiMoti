using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    /* 値 */
    [Header("Values")]
    [SerializeField] float moveSpeed;       // 移動速度
    [SerializeField] float moveRigion;      // 可動範囲

    int xDir = 1;

    [Header("Components")]
    [SerializeField] Rigidbody2D rb;

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
        Move();
    }

    //-------------------------------------------------------------------

    void Move()
    {
        rb.velocity = new Vector2(moveSpeed * xDir, 0);     // 移動

        // 方向転換
        if (transform.position.x > moveRigion) {            // 右はみ出し
            xDir = -1;
        }

        else if (transform.position.x < -moveRigion) {      // 左はみ出し
            xDir = 1;
        }
    }
}
