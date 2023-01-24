using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHitChecker : HitCheckerTrigger
{
    protected override void HitEnter(Collider2D collision)
    {
        GameManager.isResult = true;
        CameraController.Instance.Zoom(collision.gameObject);
    }

    protected override void HitExit(Collider2D collision)
    {
        
    }
}
