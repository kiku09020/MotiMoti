using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/* もちをくっつかせる処理 */
public class MotiSticker : MonoBehaviour
{
    /* 値 */
    bool isStickedOnce;     // 最初に触れたとき

    [SerializeField] float jumpForce;       // 反対方向に飛ぶジャンプ力
    [SerializeField] float returnTime;      // 親元に戻るまでの時間
    [SerializeField] Ease ease;             // イージングの種類

    /* コンポーネント取得用 */
    Moti moti;

    MotiParticleController part;

//-------------------------------------------------------------------
    void Awake()
    {
        /* オブジェクト取得 */
        Transform partObj = transform.Find("ParticleController");

        /* コンポーネント取得 */
        moti = GetComponent<Moti>();

        part = partObj.GetComponent<MotiParticleController>();

        /* 初期化 */
        
    }

//-------------------------------------------------------------------
    // くっつく
    public void Stick()
	{
        // 触れているとき
        if (moti.Ground.IsGround) {
            // 一度
            if (!isStickedOnce) {
                StickEnter();
            }

            moti.RB.velocity = Vector2.zero;                 // vel=0
            moti.RB.gravityScale = 0;                        // 重力無効化
        }

        // 触れていないとき
        else {
            NotSticking();
        }
    }

    // くっついた瞬間の処理
    void StickEnter()
	{
        part.Play(MotiParticleController.ParticleNames.ground, moti.Ground.HitPoint);

        moti.RB.constraints = RigidbodyConstraints2D.FreezeAll;

        isStickedOnce = true;
    }

    // 離れる瞬間
    void NotSticking()
    {
        moti.RB.gravityScale = 1;                        // 重力戻す

        moti.RB.constraints = RigidbodyConstraints2D.FreezeRotation;

        isStickedOnce = false;
    }

    // タップされた瞬間の処理
    public void Tapped()
    {
        moti.RB.gravityScale = 1;                                            // 重力元に戻す
        moti.RB.constraints = RigidbodyConstraints2D.FreezeRotation;

        moti.RB.AddForce(moti.Ground.HitVector * jumpForce * -1);            // 触れたオブジェクトの反対方向にジャンプ

        // 子がいるとき
        foreach (var child in moti.Family.Children) {
            if (child) {
                transform.DOMove(child.transform.position, returnTime).SetEase(ease);   // 子のところに移動
            }
        }

        // 親がいるとき
        if (moti.Family.ExistParent) {
            transform.DOMove(moti.Family.Parent.transform.position, returnTime).SetEase(ease);   // 親のところに移動
        }

        moti.Input.IsInTapped = false;
    }
}
