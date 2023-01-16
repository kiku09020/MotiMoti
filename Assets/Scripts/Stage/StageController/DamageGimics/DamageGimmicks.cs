using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGimmicks : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Moti") {
            GameManager.isResult = true;        // ‚à‚¿‚ªG‚ê‚½‚çƒŠƒUƒ‹ƒg
        }
    }
}
