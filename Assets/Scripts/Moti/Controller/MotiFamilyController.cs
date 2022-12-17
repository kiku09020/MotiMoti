using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    public class MotiFamilyController : MonoBehaviour
    {
        /* 値 */
        bool isSingle;              // どちらもいない

        /* もち */
        MotiController moti;        // 自分

        MotiController parent;      // 親
        MotiController child;       // 子

        /* プロパティ */
        public bool IsSingle => isSingle;

        public MotiController Parent => parent;
        public MotiController Child => child;

        //-------------------------------------------------------------------
        // コンストラクタ
        public MotiFamilyController(MotiController moti)
        {
            this.moti = moti;
        }

        // 子供の初期化
        void InitChild()
        {
            child.Line.Init();
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
            child.Family.parent = moti;
        }

        // 親をnull
        public void RemoveParent()
        {
            if (parent) {
                parent = null;                              // 親消す
            }
        }

        //-------------------------------------------
        /* 子 */

        // 子を追加する(子をReturnする)
        public void AddChild()
        {
            child = Instantiate(moti, InputChecker.MousePosWorld,
                                Quaternion.identity, moti.Folder);      // 子のインスタンス化

            InitChild();            // 初期化
            SetParent();            // 親を指定
        }

        // 子を減らす
        public void RemoveChild()
        {
            if (child) {
                child = null;
            }
        }

        //-------------------------------------------
        // もちの親子関係のチェック
        void CheckExistFamily()
        {
            isSingle = (!child && !parent) ? true : false;      // どちらでもない
        }
    }
}