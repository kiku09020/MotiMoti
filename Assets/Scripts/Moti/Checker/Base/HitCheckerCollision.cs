using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class HitCheckerCollision : HitCheckerBase
{
    //-------------------------------------------------------------------
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Action<Collision2D> act = HitEnter_Base;
        Checker(collision, act);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Action<Collision2D> act = HitExit_Base;
        Checker(collision, act);
    }

    void Checker(Collision2D collision, Action<Collision2D> action)
    {
        // レイヤーチェック
        if (collision.gameObject.layer == TargetLayer.value) {
            // タグチェック
            if (collision.gameObject.tag == targetTag && !isTrigger) {
                action(collision);      // action
            }
        }
    }

    void HitEnter_Base(Collision2D collision)
    {
        IsHit = true;
        HitEnter(collision);
    }

    void HitExit_Base(Collision2D collision)
    {
        IsHit = false;
        HitExit(collision);
    }

    //-------------------------------------------------------------------
    protected abstract void HitEnter(Collision2D collision);
    protected abstract void HitExit(Collision2D collision);
}
