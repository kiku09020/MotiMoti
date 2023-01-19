using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;

public abstract class HitCheckerTrigger : HitCheckerBase
{
    //-------------------------------------------------------------------
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Action<Collider2D> act = HitEnter_Base;
        Checker(collision, act);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Action<Collider2D> act = HitExit_Base;
        Checker(collision, act);
    }

    void Checker(Collider2D collision, Action<Collider2D> action)
    {
        // レイヤーチェック
        if (collision.gameObject.layer == TargetLayer.value) {
            // タグチェック
            if (collision.gameObject.tag == targetTag && isTrigger) {
                action(collision);      // action
            }
        }
    }

    void HitEnter_Base(Collider2D collision)
    {
        IsHit = true;
        HitEnter(collision);
    }

    void HitExit_Base(Collider2D collision)
    {
        IsHit = false;
        HitExit(collision);
    }

    //-------------------------------------------------------------------
    protected abstract void HitEnter(Collider2D collision);
    protected abstract void HitExit(Collider2D collision);
}
