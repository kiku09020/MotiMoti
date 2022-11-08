using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotiParticleController : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] float maxPlayTime = 10;            // 最大再生時間。これを過ぎると自動で削除する

    [Header("Particles")]
    [SerializeField] List<GameObject> particleObjs;     // パーティクルオブジェクト

    Transform particleParent;

    // パーティクル名
    public enum ParticleNames {
        ground,
    }

//-------------------------------------------------------------------
    void Awake()
    {
        GameObject partObj = GameObject.Find("ParticleManager");
        particleParent = partObj.transform.Find("Particles");

        // particlesにpartileObjsのパーティクルを格納(仮)
        for(int i = 0; i < particleObjs.Count; i++) {
            particleObjs[i].GetComponent<ParticleSystem>();
        }
    }

//-------------------------------------------------------------------
    // パーティクルの再生
    public void Play(ParticleNames particleName,Vector2 pos)
    {
        ParticleSystem part = particleObjs[(int)particleName].GetComponent<ParticleSystem>();

        // 削除までの時間
        float duration = part.main.duration;
        float lifeTime = part.main.startLifetimeMultiplier;
        float delTime = duration + lifeTime;

        GameObject inst = Instantiate(particleObjs[(int)particleName], pos, Quaternion.identity, particleParent);       // パーティクルプレハブのインスタンス化
        Destroy(inst, delTime);                                                                                         // 再生してからパーティクルオブジェクト削除
    }
}
