using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChecker : HitCheckerTrigger
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void HitEnter(Collider2D collision)
    {
        var item = collision.GetComponent<Item>();
        item.Getted();
    }

    protected override void HitExit(Collider2D collision)
    {
        throw new System.NotImplementedException();
    }

}
