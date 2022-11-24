using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/* もちを伸ばす処理 */
public class MotiStretcher : MonoBehaviour
{
    /* 値 */
    [Header("分裂")]
    [SerializeField] float minSize;                 // 最小サイズ

    [Header("固定")]
    [SerializeField] float fixingTime;              // 固定までの時間
    [SerializeField] Ease fixingEase;               // 固定のイージングの種類

    [Header("長さ")]
    [SerializeField] float stretchableLength;       // 伸ばせる長さ
    float length;                                   // 現在の長さ

    Vector2 targetPos;                              // 目標座標
    Vector2 fixedPos;                               // 固定位置

    /* フラグ */
    bool isStretching;                              // 伸びてるか

    /* プロパティ */
    public bool IsStretching => isStretching;

    public float Length => length;

    /* コンポーネント取得用 */
    Moti moti;
    Moti child;

//-------------------------------------------------------------------
    void Awake()
    {
        /* コンポーネント取得 */
        moti = GetComponent<Moti>();

    }

    //-------------------------------------------------------------------
    public void StretchingUpdate()
    {
        // タップ中
        if (moti.Input.IsTapping) {

        }

        // 子 = 親が終了したとき
        else if (moti.Family.ExistParent) {
            isStretching = moti.Family.Parent.Stretcher.IsStretching;
        }

        // 親、独身
        else {
            isStretching = false;               // Strething終了
        }

        DivisionDrag();                         // ドラッグ
    }

    // 分裂のドラッグ操作
    void DivisionDrag()
	{
        if (!moti.Input.IsOnMoti && moti.Input.IsDraging) {
            if (!isStretching) {
                Division();         // 分裂した瞬間
            }

            MoveChild();            // 分裂した子の移動
        }
	}

    // 分裂(ドラッグ開始時)
    void Division()
    {
        if (moti.transform.localScale.x >= minSize * 2) {       // 大きさ制限
            fixedPos = (transform.position + (Vector3)moti.Ground.HitPoint) / 2;                    // 固定位置の指定
            transform.position = fixedPos;                                                          // 固定

            moti.transform.localScale /= 2;                                                         // 大きさを半分にする

            child = moti.Family.AddChild(moti);                                                     // 子作成

            isStretching = true;                                                                    // Stretching状態
        }
    }

    // 子の移動(ドラッグ中)
    void MoveChild()
	{
        if (child) {
            if (!child.Ground.IsGround) {
                length = Vector2.Distance(transform.position, child.transform.position);        // 子との距離求める
                child.transform.position = moti.Input.MousePosWorld;
            }

            child.RB.velocity = Vector2.zero;                           // rb無効化
        }
    }
}
