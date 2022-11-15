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
    [SerializeField] DG.Tweening.Ease ease; // イージングの種類

    /* コンポーネント取得用 */
    Rigidbody2D rb;

    Moti moti;

    MotiParticleController part;

//-------------------------------------------------------------------
    void Awake()
    {
        /* オブジェクト取得 */
        Transform partObj = transform.Find("ParticleController");

        /* コンポーネント取得 */
        rb = GetComponent<Rigidbody2D>();

        moti = GetComponent<Moti>();

        part = partObj.GetComponent<MotiParticleController>();

        /* 初期化 */
        
    }

    void FixedUpdate()
    {
        Stick();
    }

//-------------------------------------------------------------------
    // くっつく
    void Stick()
	{
        // 触れているとき
        if (moti.Ground.IsGround) {
            // 一度
            if (!isStickedOnce) {
                StickEnter();

                isStickedOnce = true;
            }

            rb.velocity = Vector2.zero;                 // vel=0
            rb.gravityScale = 0;                        // 重力無効化

            // タップされたとき
            if (moti.Input.IsInTapped) {
                Tapped();
            }
        }

        // 触れていないとき
        else {
            rb.gravityScale = 1;                        // 重力戻す
            isStickedOnce = false;
        }
    }

    // くっついた瞬間の処理
    void StickEnter()
	{
        part.Play(MotiParticleController.ParticleNames.ground, moti.Ground.HitPoint);
	}

    // タップされた瞬間の処理
    void Tapped()
    {
        rb.gravityScale = 1;                                            // 重力元に戻す
        rb.AddForce(moti.Ground.HitVector * jumpForce * -1);            // 触れたオブジェクトの反対方向にジャンプ

        // クローンがいるとき
        
        foreach(var child in moti.Family.Children)
        if (child) {
        transform.DOMove(child.transform.position, returnTime).SetEase(ease);   // 相手のところに移動

        }

        // 親元がいるとき
        if (moti.Family.Parent) {
            transform.DOMove(moti.Family.Parent.transform.position, returnTime).SetEase(ease);   // 相手のところに移動

        }

        // なんもいないとき
        else {

        }

        moti.Input.IsInTapped = false;                                  // タップフラグ元に戻す
    }
}
