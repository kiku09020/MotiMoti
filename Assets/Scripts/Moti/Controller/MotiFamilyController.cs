using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
    public class MotiFamilyController : MonoBehaviour
    {
        /* 値 */
        bool existParent;                               // 親がいるか
        bool existChild;                                // 子がいるか
        bool isSingle;                                    // どちらもいない

        /* もち */
        MotiController moti;                                      // 自分
        MotiController parent;                                    // 親
        List<MotiController> children = new List<MotiController>();         // 子のリスト

        /* プロパティ */
        public bool ExistChild => existChild;
        public bool ExistParent => existParent;
        public bool IsSingle => isSingle;

        public MotiController Parent => parent;
        public List<MotiController> Children => children;


        //-------------------------------------------------------------------
        // コンストラクタ
        public MotiFamilyController(MotiController moti)
        {
            this.moti = moti;
        }

        // 子供の初期化
        void InitChild(MotiController child)
        {
            child.Line.Init();
        }

        // くっついてるもちのチェック
        public void CheckExistFamily()
        {
            existChild = children.Count > 0 ? true : false;             // 子
            existParent = parent ? true : false;                        // 親

            isSingle = (!existChild && !existParent) ? true : false;      // どちらでもない
        }

        //-------------------------------------------
        // 親を指定する
        void SetParent(MotiController child)
        {
            child.Family.parent = moti;
        }

        // 親をnull
        public void RemoveParent()
        {
            if (existParent) {
                parent.Family.RemoveChild(moti);            // 子(自分)を親から消す
                parent = null;                              // 親消す
            }
        }

        // 子を追加する(子をReturnする)
        public MotiController AddChild(MotiController parent)
        {
            var child = Instantiate(parent, InputChecker.MousePosWorld,
                                    Quaternion.identity, moti.Folder);      // 子のインスタンス化

            children.Add(child);                                            // 子をリストに追加
            InitChild(child);                                               // 初期化
            SetParent(child);                                               // 親を指定

            return child;
        }

        // 子を減らす
        public void RemoveChild(MotiController child)
        {
            if (existChild) {
                children.Remove(child);
            }
        }

        // 子を全て減らす
        public void RemoveChildren()
        {
            if (existChild) {
                children.Clear();
            }
        }

        //-------------------------------------------
        // 自分の子かを調べる
        public bool CheckIfChild(MotiController moti)
        {
            foreach (var child in children) {
                if (moti == child) {
                    return true;
                }
            }

            return false;
        }

    }
}