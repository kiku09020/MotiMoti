using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* もちを伸ばす処理 */
public class MotiStretcher : MonoBehaviour
{
    /* 値 */
    bool stretching;          // 分裂

    Transform motiParent;       // クローンのparent指定用

    /* プロパティ */
    public bool Stretching => stretching;

    public Moti Clone => motiClone;

    /* コンポーネント取得用 */
    Rigidbody2D rb;

    Moti moti;
    Moti motiClone;             // 分裂でできるクローン


//-------------------------------------------------------------------
    void Awake()
    {
        /* オブジェクト取得 */
        motiParent = GameObject.Find("Motis").transform;

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
            stretching = false;
        }

        DivisionDrag();
    }

//-------------------------------------------------------------------
    // 分裂のドラッグ操作
    void DivisionDrag()
	{
		if (moti.Input.IsDraging) {
            if (!stretching) {
                Division();
            }

            MoveClone();
        }
	}

    // 分裂(ドラッグ開始時)
    void Division()
    {
        moti.transform.position = moti.Ground.HitPoint;
        moti.transform.localScale /= 2;                                                         // 大きさを半分にする
        motiClone = Instantiate(moti, transform.position, Quaternion.identity, motiParent);     // クローン作成

        motiClone.InitClonedMoti();                                                             //クローン初期化
        motiClone.Stretcher.stretching = true;
        print(motiClone);

        stretching = true;
    }

    // クローンの移動(ドラッグ中)
    void MoveClone()
	{
        if (motiClone != null) {
            motiClone.transform.position = moti.Input.MousePosWorld;                            // クローンの移動
            motiClone.RB.velocity = Vector2.zero;                                               // rb無効化
        }
    }
}
