using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ParticleManager<T> : Singleton<T> where T:ParticleManager<T> 
{
    protected abstract string FilePath { get; }     // filePath

    protected List<ParticleSystem> generatedParticles = new List<ParticleSystem>();      // 生成されたパーティクルのリスト
    protected Dictionary<string, GameObject> dic;       // dic

    Transform parent;

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
    protected virtual void SetUp(ParticleSystem part,Transform parent, ParticleSystemStopAction stopAction)
    {
        this.parent = parent;                   // 親指定

        // 親指定なしの場合、自分を親と指定
        if(!this.parent) {
            parent = transform;
        }

        var partMain = part.main;
        partMain.stopAction = stopAction;       // 再生終了時の処理
    }

    //-------------------------------------------------------------------
    /// <summary>
    /// パーティクル再生
    /// </summary>
    public virtual GameObject Play(string particleName, Vector2 position, Transform parent=null, 
                                ParticleSystemStopAction stopAction = ParticleSystemStopAction.Destroy)
    {
        var partObj = dic[particleName];
        var part = partObj.GetComponent<ParticleSystem>();
        SetUp(part,parent, stopAction);                                     // パーティクルのセットアップ

        generatedParticles.Add(part);                                       // リストに追加
        return Instantiate(partObj, position, Quaternion.identity, this.parent);      // 生成
    }

    public virtual GameObject Play(string particleName, Vector2 position, Quaternion rotation, Transform parent = null,
                                ParticleSystemStopAction stopAction = ParticleSystemStopAction.Destroy)
    {
        var partObj = dic[particleName];
        var part = partObj.GetComponent<ParticleSystem>();
        SetUp(part, parent, stopAction);

        generatedParticles.Add(part);                                   // リストに追加
        return Instantiate(partObj, position, rotation, this.parent);          // 生成
    }
}
