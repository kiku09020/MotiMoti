using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Moti
{
    /* もちを伸ばす処理 */
    public class MotiStretcher : MonoBehaviour
    {
        /* 値 */
        [Header("分裂")]
        [SerializeField] float minSize;                 // 最小サイズ

        [Header("固定")]
        [SerializeField] float fixingTime;              // 固定までの時間

        [Header("移動")]
        [SerializeField] float goingTime;               // 移動時間
        [SerializeField] Ease goingEaseType;            // 移動イージング


        /* フラグ */
        bool isStretching;                              // 伸びてるか

        /* プロパティ */
        public bool IsStretching => isStretching;

        /* コンポーネント取得用 */
        MotiController moti;

        //-------------------------------------------------------------------
        void Awake()
        {
            /* コンポーネント取得 */
            moti = GetComponent<MotiController>();
        }

        //-------------------------------------------------------------------
        public void StretchingUpdate()
        {
            if(!moti.Input.IsTapping) {

                if (moti.Family.Parent) {
                    isStretching = moti.Family.Parent.Stretcher.isStretching;
                }

                else {
                    isStretching = false;               // Strething終了
                }
            }

            DivisionDrag();                         // ドラッグ
        }

        //-------------------------------------------------------------------
        // 分裂のドラッグ操作
        void DivisionDrag()
        {
            if (!moti.Input.IsOnMoti && moti.Input.IsDraging && moti.Ground.IsGround) {
                if (!isStretching && moti.Family.IsSingle) {
                    Division();         // 分裂した瞬間
                }

                MoveChild();            // 分裂した子の移動
            }
        }

        // 分裂(ドラッグ開始時)
        void Division()
        {
            transform.position = (transform.position + (Vector3)moti.Ground.HitPoint) / 2;    // 固定位置の指定
            moti.transform.localScale /= 2;                                         // 大きさを半分にする

            moti.Family.AddChild();                                                 // 子作成
            isStretching = true;                                                    // Stretching状態
        }

        //-------------------------------------------------------------------
        // 子の移動(ドラッグ中)
        void MoveChild()
        {
            var child = moti.Family.Child;

            if (child && !child.Ground.IsGround) {

                // 通常移動
                if (!child.Line.IsLimit) {
                    child.transform.position = InputChecker.MousePosWorld;
                }
            }
        }

        public void GoingMove(MotiController targetMoti)
        {
            if (targetMoti) {
                transform.DOMove(targetMoti.Pos, goingTime).SetEase(goingEaseType);
            }
        }
    }
}