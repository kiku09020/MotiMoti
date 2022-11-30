using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/* もちを合体させる処理 */
public class MotiUniter : MonoBehaviour
{
    /* 値 */
    bool isUnitable;        // 合体可能か

    /* プロパティ */
    public bool IsUnitable => isUnitable;

    /* コンポーネント取得用 */
    Moti moti;


//-------------------------------------------------------------------
    void Awake()
    {
        /* オブジェクト取得 */


        /* コンポーネント取得 */
        moti = GetComponent<Moti>();

        /* 初期化 */
        
    }

    //-------------------------------------------------------------------
    public void Unite()
    {
        HitChecker hit = moti.MotiHit;

        transform.localScale += hit.OtherMoti.transform.localScale;                         // 大きさ変更
        moti.Line.StretchableLenth += hit.OtherMoti.Line.StretchableLenth;

        // 演出
        moti.Particle.Play(ParticleNames_Moti.united, transform.position);
        moti.Audio.Play(MotiAudioNames.united);

        Destroy(hit.OtherMoti.gameObject);                                                  // 削除
    }

    // 合体可能かを調べる
    public void CheckUnitable()
	{
        HitChecker hit = moti.MotiHit;

        if (hit.IsMotiTrigger) {     // 近くに他のもちがいるとき
            isUnitable = true;
        }

        else {
            isUnitable = false;
        }
	}
}
