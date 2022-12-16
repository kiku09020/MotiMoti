using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Moti
{
    /* もちをくっつかせる処理 */
    public class MotiSticker : MonoBehaviour
    {
        /* 値 */
        bool isStickedOnce;     // 最初に触れたとき
        bool isStickExitOnce;   // 最初に離れた時

        [SerializeField] float jumpForce;       // 反対方向に飛ぶジャンプ力
        [SerializeField] float returnTime;      // 親元に戻るまでの時間
        [SerializeField] Ease ease;             // イージングの種類

        /* コンポーネント取得用 */
        MotiController moti;

        //-------------------------------------------------------------------
        void Awake()
        {
            /* コンポーネント取得 */
            moti = GetComponent<MotiController>();

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
            }

            // 触れていないとき
            else {
                if (!isStickExitOnce) {
                    StickExit();
                }
            }
        }

        // くっついた瞬間の処理
        void StickEnter()
        {
            moti.Particle.Play(ParticleNames_Moti.ground, moti.Ground.HitPoint);

            moti.RB.constraints = RigidbodyConstraints2D.FreezeAll;

            isStickedOnce = true;
            isStickExitOnce = false;
        }

        // 離れる瞬間
        void StickExit()
        {
            moti.RB.constraints = RigidbodyConstraints2D.FreezeRotation;

            isStickExitOnce = true;
            isStickedOnce = false;
        }
    }
}