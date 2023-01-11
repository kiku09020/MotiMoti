using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HitCheckerCollision : HitCheckerBase
{
    //-------------------------------------------------------------------
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == targetTagName && !isTrigger) {
            IsHit = true;
            HitEnter(collision);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == targetTagName && !isTrigger) {
            IsHit = false;
            HitExit(collision);
        }
    }

    //-------------------------------------------------------------------
    protected abstract void HitEnter(Collision2D collision);
    protected abstract void HitExit(Collision2D collision);
}
