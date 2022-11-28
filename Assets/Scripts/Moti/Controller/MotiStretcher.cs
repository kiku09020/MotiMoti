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

    [Header("移動")]
    [SerializeField] float moveTime;                // 通常移動時の移動時間
    [SerializeField] float limitMoveTime;           // 限界移動時の移動時間
    [SerializeField] float leaveTime;               // 離れるまでの時間
    float limitTimer;                               // 限界移動時になってからの時間

    Vector2 limitPos;                               // 限界点
    Vector2 fixedPos;                               // 固定位置

    /* フラグ */
    bool isStretching;                              // 伸びてるか
    bool isLimit;                                   // 限界点

    /* プロパティ */
    public bool IsStretching => isStretching;

    public float Length => length;
    public float StretchableLenth       { get => stretchableLength; set => stretchableLength = value; }

    /* コンポーネント取得用 */
    Moti moti;
    Moti child;

    Tween moveTween;
    Tween lowMove;

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

        else {
            lowMove.Kill();

            limitTimer = 0;
            isLimit = false;
        }
    }

    // 分裂(ドラッグ開始時)
    void Division()
    {
        if (moti.transform.localScale.x >= minSize * 2) {       // 大きさ制限
            fixedPos = (transform.position + (Vector3)moti.Ground.HitPoint) / 2;                    // 固定位置の指定
            transform.position = fixedPos;                                                          // 固定

            moti.transform.localScale /= 2;                                                         // 大きさを半分にする
            stretchableLength /= 2;                                                                 // 伸ばせる長さも半分にする

            child = moti.Family.AddChild(moti);                                                     // 子作成

            isStretching = true;                                                                    // Stretching状態
        }
    }

    // 子の移動(ドラッグ中)
    void MoveChild()
	{
        if (child && !child.Ground.IsGround) {
            length = Vector2.Distance(transform.position, child.transform.position);        // 子との距離求める

            // 通常移動
            if (length < stretchableLength) {
                moveTween = child.transform.DOMove(moti.Input.MousePosWorld, moveTime);     // 移動

                child.RB.velocity = Vector2.zero;                                           // rb無効化
                child.RB.gravityScale = 0;                                                  // 重力無効化

                isLimit = false;
            }

            // 限界点到達時
            else {

                // 到達した瞬間
                if (!isLimit) {
                    moveTween.Kill();                                                       // 通常移動停止
                    lowMove = child.transform.DOMove(moti.Input.MousePosWorld, 3);          // 低速移動

                    isLimit = true;
                }

                limitTimer += Time.deltaTime;                                               // タイマー増加

                // 時間経過時
                if (limitTimer > leaveTime) {
                    moti.Audio.Play(MotiAudioNames.united);

                    // 親子関係の破棄
                    moti.Family.RemoveChild(child);
                    child.Family.RemoveParent();
                    child = null;

                    lowMove.Kill();                                                         // 移動停止
                    isLimit = false;
                    length = 0;
                    limitTimer = 0;
                }
            }

            print(length);
        }
    }
}
