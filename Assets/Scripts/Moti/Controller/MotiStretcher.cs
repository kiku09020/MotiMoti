using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* もちを伸ばす処理 */
public class MotiStretcher : MonoBehaviour
{
    /* 値 */
    [Header("分裂")]
    [SerializeField] float minSize;                 // 最小サイズ

    [Header("固定")]
    [SerializeField] float fixingTime;              // 固定までの時間

    [Header("移動")]
    [SerializeField] float leaveTime;               // 離れるまでの時間
    [SerializeField] float audioTimeSpan;           

    Vector2 fixedPos;                               // 固定位置

    /* フラグ */
    bool isStretching;                              // 伸びてるか

    /* プロパティ */
    public bool IsStretching => isStretching;

    /* コンポーネント取得用 */
    Moti moti;
    Moti activeChild;                               // 操作される子

//-------------------------------------------------------------------
    void Awake()
    {
        /* コンポーネント取得 */
        moti = GetComponent<Moti>();
    }

    public void RemoveActiveChild()
    {
        if (activeChild) {
            activeChild.Family.RemoveParent();
            activeChild = null;

            print("aaaa");
        }
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
        if (!moti.Input.IsOnMoti && moti.Input.IsDraging && moti.Ground.IsGround) {
            if (!isStretching) {
                Division();         // 分裂した瞬間
            }

            if (activeChild) {
                MoveChild();            // 分裂した子の移動
            }
        }
    }

    // 分裂(ドラッグ開始時)
    void Division()
    {
        if (moti.transform.localScale.x >= minSize * 2) {       // 大きさ制限
            fixedPos = (transform.position + (Vector3)moti.Ground.HitPoint) / 2;                    // 固定位置の指定
            transform.position = fixedPos;                                                          // 固定

            moti.transform.localScale /= 2;                                                         // 大きさを半分にする
            moti.Line.StretchableLenth /= 2;

            activeChild = moti.Family.AddChild(moti);                                               // 子作成

            isStretching = true;                                                                    // Stretching状態
        }
    }

    // 子の移動(ドラッグ中)
    void MoveChild()
	{
        if (activeChild && !activeChild.Ground.IsGround) {

            // 通常移動
            if (!activeChild.Line.IsLimit && !activeChild.Line.IsSpring) {
                activeChild.transform.position = InputChecker.MousePosWorld;

                activeChild.RB.velocity = Vector2.zero;                         // rb無効化
                activeChild.RB.gravityScale = 0;                                // 重力無効化
            }
        }
    }
}
