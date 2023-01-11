using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HitCheckerTrigger : HitCheckerBase
{
    //-------------------------------------------------------------------
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == targetTagName && isTrigger) {
            IsHit = true;
            HitEnter(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == targetTagName && isTrigger) {
            IsHit = false;
            HitExit(collision);
        }
    }

    //-------------------------------------------------------------------
    protected abstract void HitEnter(Collider2D collision);
    protected abstract void HitExit(Collider2D collision);
}
