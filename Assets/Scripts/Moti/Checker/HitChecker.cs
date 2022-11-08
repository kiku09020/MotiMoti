using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitChecker : MonoBehaviour
{
    /* 値 */
    bool isGround;      // 着地しているか

    /* プロパティ */
    public bool IsGround => isGround;

    /* コンポーネント取得用 */
    Moti moti;

    //-------------------------------------------------------------------
    private void Awake()
    {
        moti = transform.parent.GetComponent<Moti>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // 着地時
        if (col.gameObject.tag == "Stage") {
            isGround = true;
            moti.Particle.Play(MotiParticleController.ParticleNames.ground,transform.position);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        // 離れるとき
        if (col.gameObject.tag == "Stage") {
            isGround = false;
        }
    }
}
