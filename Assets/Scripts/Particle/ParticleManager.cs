using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ParticleManager<T> : Singleton<T> where T:ParticleManager<T> 
{
    protected abstract string FilePath { get; }     // filePath

    protected List<ParticleSystem> generatedParticles = new List<ParticleSystem>();      // 生成されたパーティクルのリスト
    protected Dictionary<string, GameObject> dic;       // dic


    //-------------------------------------------------------------------
    protected override void Awake()
    {
        base.Awake();

        SetParticleObjects();
    }

    // Resourceフォルダから、particle取得
    protected void SetParticleObjects()
    {
        dic = new Dictionary<string, GameObject>();
        object[] list = Resources.LoadAll(FilePath);

        foreach(GameObject part in list) {
            dic[part.name] = part;
        }
    }

    // 再生前にセットアップ
    protected virtual void SetUp(ParticleSystem part,ParticleSystemStopAction stopAction)
    {
        var partMain = part.main;
        partMain.stopAction = stopAction;       // 再生終了時の処理
    }

    //-------------------------------------------------------------------
    /// <summary>
    /// パーティクル再生
    /// </summary>
    public virtual void Play(string particleName, Vector2 position, 
                                ParticleSystemStopAction stopAction = ParticleSystemStopAction.Destroy)
    {
        var partObj = dic[particleName];
        var part = partObj.GetComponent<ParticleSystem>();
        SetUp(part, stopAction);                                            // パーティクルのセットアップ

        Instantiate(part, position, Quaternion.identity, transform);        // 生成
        generatedParticles.Add(part);                                       // リストに追加
    }

    public virtual void Play(string particleName, Vector2 position, Quaternion rotation,
                                ParticleSystemStopAction stopAction = ParticleSystemStopAction.Destroy)
    {
        var partObj = dic[particleName];
        var part = partObj.GetComponent<ParticleSystem>();

        Instantiate(partObj, position, rotation, transform);        // 生成
        generatedParticles.Add(part);        // リストに追加
    }
}
