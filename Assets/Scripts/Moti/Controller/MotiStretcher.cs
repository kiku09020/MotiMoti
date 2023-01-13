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
        [SerializeField] float divisionLength;          // 分裂する長さ

        [Header("固定")]
        [SerializeField] float fixingTime;              // 固定までの時間

        [Header("移動")]
        [SerializeField] float moveSpeed;
        [SerializeField] Ease goingEaseType;            // 移動イージング
        [SerializeField,Range(0.5f,2)] 
        float moveSensitivity;         // 移動感度

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
            if (!GameManager.isResult) {
                if (!InputChecker.IsTapping) {
                    // 子は親に合わせる
                    if (moti.Family.HasParent) {
                        isStretching = moti.Family.OtherMoti.Stretcher.isStretching;
                    }

                    else {
                        isStretching = false;               // Strething終了
                    }
                }

                DivisionDrag();                         // ドラッグ
            }
        }

        //-------------------------------------------------------------------
        // 分裂のドラッグ操作
        void DivisionDrag()
        {
            if (InputChecker.IsTapping && moti.Ground.IsHit) {
                if (!isStretching && moti.Family.IsSingle) {
                    Division();         // 分裂した瞬間
                }

                MoveChild();            // 分裂した子の移動
            }
        }

        // 分裂(ドラッグ開始時)
        void Division()
        {
            // 指定の長さで分裂
            if (InputChecker.MouseDistance > divisionLength) {
                transform.position = (transform.position + (Vector3)moti.Ground.HitPoint) / 2;    // 固定位置の指定
                moti.transform.localScale /= 2;                                         // 大きさを半分にする

                moti.Family.SetChild();                                                 // 子作成
                isStretching = true;                                                    // Stretching状態
            }
        }

        //-------------------------------------------------------------------
        // 子の移動(ドラッグ中)
        void MoveChild()
        {
            var child = moti.Family.OtherMoti;

            if (child &&InputChecker.IsTapping && isStretching) {
                child.transform.position = moti.transform.position + (InputChecker.MouseVector * moveSensitivity);          // 通常移動

                // 指定の長さを超えたら、円形の移動制限をかける
                if (InputChecker.MouseDistance > moti.Line.StretchableLenth) {
                    var offset = child.transform.position - moti.transform.position;
                    var clamoedPos = Vector2.ClampMagnitude(offset, moti.Line.StretchableLenth);

                    child.transform.position = clamoedPos + (Vector2)moti.transform.position;       // 制限移動
                }
            }
        }

        // 移動
        public void GoingMove(MotiController targetMoti)
        {
            var time = 0f;
            if(moti.Family.HasParent){
                time = targetMoti.Line.Length / moveSpeed;
			}

            else if(moti.Family.HasChild){
                time = moti.Line.Length / moveSpeed;
			}

            if (targetMoti) {
                transform.DOMove(targetMoti.transform.position, time).SetEase(goingEaseType);
            }
        }
    }
}