using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Motigome {
    [RequireComponent(typeof(Rigidbody2D))]
    public class MotigomeController : MonoBehaviour
    {
        /* 値 */
        [Header("Values")]
        [SerializeField] float jumpForce;       // ジャンプ力

        /* プロパティ */


        public GroundChecker Ground => ground;

        /* コンポーネント取得用 */
        [Header("Components")]
        [SerializeField] Rigidbody2D rb;
        [SerializeField] Collider2D col;

        [SerializeField] GroundChecker ground;

        //-------------------------------------------------------------------
        void Awake()
        {
            /* オブジェクト取得 */


            /* コンポーネント取得 */


            /* 初期化 */

        }

        void FixedUpdate()
        {
            Jump();
        }

        //-------------------------------------------------------------------
        // ジャンプ
        void Jump()
        {
            if (ground.IsGround) {
                rb.AddForce(Vector2.up * jumpForce);
            }
        }
    }
}