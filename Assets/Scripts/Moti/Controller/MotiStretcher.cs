using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* もちを伸ばす処理 */
public class MotiStretcher : MonoBehaviour
{
    /* 値 */
    bool stretching;            // 分裂

    /* プロパティ */
    public bool Stretching => stretching;

    /* コンポーネント取得用 */
    Rigidbody2D rb;

    Moti moti;
    Moti child;

//-------------------------------------------------------------------
    void Awake()
    {
        /* オブジェクト取得 */

        /* コンポーネント取得 */
        rb = GetComponent<Rigidbody2D>();

        moti = GetComponent<Moti>();

        /* 初期化 */
        
    }

    void FixedUpdate()
    {
        // タップ中
        if (moti.Input.IsTapping) {

        }

        // タップ終了時
        else {
            stretching = false;             // Strething終了
        }

        DivisionDrag();
    }

//-------------------------------------------------------------------
    // 分裂のドラッグ操作
    void DivisionDrag()
	{
		if (moti.Input.IsDraging) {
            if (!stretching) {
                Division();         // 分裂した瞬間
            }

            MoveChild();            // 分裂した子の移動
        }
	}

    // 分裂(ドラッグ開始時)
    void Division()
    {
        moti.transform.position = moti.Ground.HitPoint;
        moti.transform.localScale /= 2;                                                         // 大きさを半分にする

        child = moti.Family.AddChild(moti);                                                         // 子作成

        child.Stretcher.stretching = true;                                                      // 子もStretching状態に指定
        stretching = true;                                                                      // Stretching状態
    }

    // 子の移動(ドラッグ中)
    void MoveChild()
	{
        if (child != null) {
            child.transform.position = moti.Input.MousePosWorld;                            // 子の移動
            child.RB.velocity = Vector2.zero;                                               // rb無効化
        }
    }
}
