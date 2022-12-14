using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    public class MotiFamilyController : MonoBehaviour
    {
        /* 値 */
        bool isSingle;              // どちらもいない
        bool hasChild;
        bool hasParent;

        /* もち */
        MotiController moti;        // 自分
        MotiController otherMoti;   // 片方

        /* プロパティ */
        public bool IsSingle => isSingle;
        public bool HasChild => hasChild;
        public bool HasParent => hasParent;

        public MotiController OtherMoti => otherMoti;


        //-------------------------------------------------------------------
        // コンストラクタ
        public MotiFamilyController(MotiController moti)
        {
            this.moti = moti;
        }

        // 子供の初期化
        void InitChild()
        {
            otherMoti.Line.Init();
        }

        public void FamilyUpdate()
        {
            CheckExistFamily();
        }

        //-------------------------------------------
        /* 親 */

        // 親を指定する
        void SetParent()
        {
            otherMoti.Family.otherMoti= moti;
            otherMoti.Family.hasParent = true;
        }

        // 親をnull
        public void RemoveParent()
        {
            if (hasParent) {
                otherMoti = null;                              // 親消す
                hasParent = false;
            }
        }

        //-------------------------------------------
        /* 子 */

        // 子を追加する
        public void SetChild()
        {
            otherMoti = Instantiate(moti, InputChecker.MousePosWorld,
                                    Quaternion.identity, moti.Folder);      // 子のインスタンス化

            hasChild = true;

            InitChild();            // 初期化
            SetParent();            // 親を指定
        }

        // 子を減らす
        public void RemoveChild()
        {
            if (hasChild) {
                otherMoti.Family.RemoveParent();
                otherMoti = null;
                hasChild = false;
            }
        }

        //-------------------------------------------
        // もちの親子関係のチェック
        void CheckExistFamily()
        {
            isSingle = (!hasChild && !hasParent) ? true : false;      // どちらでもない
        }
    }
}