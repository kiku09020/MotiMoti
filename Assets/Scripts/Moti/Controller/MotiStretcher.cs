using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* もちを伸ばす処理 */
public class MotiStretcher : MonoBehaviour
{
    /* 値 */
    [SerializeField] float minSize;     // 最小サイズ
    [SerializeField] float marginValue; // 余白

    float distance;                     // 子との距離
    Vector2 targetPos;                  // 目標座標

    /* フラグ */
    bool isHit;                         // 間がステージと当たったか
    bool isStretching;                  // 伸びてるか

    /* Ray */
    Ray2D targetRay;                    // もち→マウスのRay
    int layerMask;                      // ステージのみに衝突させるためのやつ

    /* プロパティ */
    public bool IsStretching => isStretching;

    /* コンポーネント取得用 */
    Moti moti;
    Moti child;

//-------------------------------------------------------------------
    void Awake()
    {
        /* コンポーネント取得 */
        moti = GetComponent<Moti>();

        layerMask = LayerMask.GetMask("StageLayer");

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
            isStretching = false;             // Strething終了
        }

        DivisionDrag();
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
            transform.position = (transform.position + (Vector3)moti.Ground.HitPoint) / 2;          // 位置固定
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
                SetTargetPos();                                                                     // 目標地点の指定
                child.transform.position = targetPos;                                               // 子の移動
                distance = Vector2.Distance(transform.position, child.transform.position);          // 子との距離求める
            }

            child.RB.velocity = Vector2.zero;                           // rb無効化
        }
    }

    // 目標座標の指定
    void SetTargetPos()
    {
        var localMousePos = transform.InverseTransformPoint(moti.Input.MousePosWorld);          // マウス座標をローカル座標に変換

        targetRay = new Ray2D(transform.position, localMousePos);                               // Ray生成

        RaycastHit2D hit = Physics2D.Raycast(targetRay.origin, targetRay.direction, distance, layerMask);       // 当たり判定

        if (hit.collider) {
            if (!isHit) {
                moti.Particle.Play(MotiParticleController.ParticleNames.ground, hit.point);
                isHit = true;
            }
            
            print("hit");
        }

        else {
            if (isHit) {
                isHit = false;
            }

            targetPos = moti.Input.MousePosWorld;
        }

        Debug.DrawRay(targetRay.origin, targetRay.direction * distance, Color.black);
    }
}
