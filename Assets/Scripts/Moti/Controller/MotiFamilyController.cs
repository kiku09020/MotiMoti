using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotiFamilyController : MonoBehaviour
{
    /* 値 */
    bool existParent;                               // 親がいるか
    bool existChild;                                // 子がいるか
    bool isSingle;                                    // どちらもいない

    /* もち */
    Moti moti;                                      // 自分
    Moti parent;                                    // 親
    List<Moti> children = new List<Moti>();         // 子のリスト

    /* プロパティ */
    public bool ExistChild => existChild;
    public bool ExistParent => existParent;
    public bool IsSingle => isSingle;

    public Moti Parent => parent;
    public List<Moti> Children => children;


    //-------------------------------------------------------------------
    // コンストラクタ
    public MotiFamilyController(Moti moti)
    {
        this.moti = moti;
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
    void SetParent(Moti child)
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
    public Moti AddChild(Moti parent)
    {
        var child = Instantiate(parent, moti.Input.MousePosWorld, Quaternion.identity, moti.Folder);    // 子のインスタンス化
        children.Add(child);                                                                            // 子をリストに追加
        SetParent(child);                                                                               // 親を指定

        return child;
    }

    // 子を減らす
    public void RemoveChild(Moti child)
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
}
