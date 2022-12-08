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

        public StateController StateCtrl => stateCtrl;
        public GroundChecker Ground => ground;
        public StickChekcer Stick => stick;

        /* コンポーネント取得用 */
        [Header("Components")]
        [SerializeField] Rigidbody2D rb;
        [SerializeField] Collider2D col;

        [SerializeField] GroundChecker ground;
        [SerializeField] StickChekcer stick;
        StateController stateCtrl;

        //-------------------------------------------------------------------
        void Awake()
        {
            /* 初期化 */
            stateCtrl = new StateController(this);

            stateCtrl.InitState(stateCtrl.Normal);
        }

        void FixedUpdate()
        {
            stateCtrl.StateUpdate();
        }

        //-------------------------------------------------------------------
        // ジャンプ
        public void Jump()
        {
            if (ground.IsGround) {
                rb.AddForce(Vector2.up * jumpForce);
            }
        }

        // くっついたときの処理
        public void Sticked()
        {

        }
    }
}