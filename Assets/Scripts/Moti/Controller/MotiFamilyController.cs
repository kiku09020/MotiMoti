using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotiFamilyController : MonoBehaviour
{
    /* 値 */
    bool existParent;
    bool existChild;

    /* もち */
    Moti moti;                                      // 自分
    Moti motiParent;                                // 子からした親
    List<Moti> motiChildren = new List<Moti>();     // 子のリスト

    /* プロパティ */
    public bool ExistChild => existChild;
    public bool ExistParent => existParent;

    public Moti Parent => motiParent;
    public List<Moti> Children => motiChildren;


    //-------------------------------------------------------------------
    // コンストラクタ
    public MotiFamilyController(Moti moti)
    {
        this.moti = moti;
    }

    // くっついてるもちのチェック
    public void CheckExistFamily()
    {
        existChild = motiChildren.Count > 0 ? true : false;         // 子
        existParent = motiParent? true : false;                     // 親
    }

    // 親を指定する
    void SetParent(Moti child)
    {
        child.Family.motiParent = moti;
    }

    // 子を追加する
    public Moti AddChild(Moti parent)
    {
        var child = Instantiate(parent, parent.transform.position, Quaternion.identity, moti.Folder);    // 子のインスタンス化
        motiChildren.Add(child);                                                                 // 子をリストに追加
        SetParent(child);                                                                        // 親を指定

        return child;
    }

    // 子を減らす
    public void RemoveChild(Moti child)
    {
        motiChildren.Remove(child);
    }
}
