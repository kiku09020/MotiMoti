using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GenerateTargetChecker))]
public abstract class GeneratorBase<T> : Singleton<T> where T :GeneratorBase<T>
{
    [Header("生成オプション")]
    [SerializeField,Tooltip("オブジェクト同士の間隔")]
    float generatedObjDist;

    [SerializeField, Tooltip("ターゲットから生成位置までの距離")]
    float generatedDistanceFromTarget;

    [SerializeField,Tooltip("生成開始地点")] 
    float startGeneratedPosY;


    [SerializeField, Tooltip("生成先")]
    protected Transform parent;

    [Header("生成タイプ")]
    [SerializeField,Tooltip("生成タイプ")]
    GenerateType generateType;

    [SerializeField,Tooltip("生成関係の値")] 
    float value;

    // 生成位置
    protected Vector2 generatedPos;

    // 生成されたオブジェクトのリスト
    List<GameObject> generatedObjList = new List<GameObject>();
    public List<GameObject> GeneratedObjList => generatedObjList;

    // 生成タイプ
    enum GenerateType {
        random,
        edge,
        constant,
    }

    IGenerateType genType;

    /* コンポーネント */
    GenerateTargetChecker targetChecker;


//-------------------------------------------------------------------
    protected override void Awake()
    {
        /* コンポーネント取得 */
        targetChecker = GetComponent<GenerateTargetChecker>();

        // 生成先が指定されていなければ、自身のtransformを生成先とする
        if (!parent) {
            parent = transform;
        }

        generatedPos = new Vector2(0,startGeneratedPosY);       // 最初の生成先の指定

        //タイプ指定
        SetGenerateType();
    }

    // 生成タイプの指定
    void SetGenerateType()
    {
        switch (generateType) {
            case GenerateType.random:       genType = new GenType_Random(); break;
            case GenerateType.edge:         genType = new GenType_Edge();   break;
            case GenerateType.constant:     genType = new GenType_Const();  break;
        }
    }


    void FixedUpdate()
    {
        if (!GameManager.isResult) {

            // ターゲットとの距離が指定より小さくなったら生成する
            if(targetChecker.CheckTargetWithinDistance(generatedDistanceFromTarget, generatedPos)) {
                Generate();
            }
        }
    }

    // 生成
    void Generate()
    {
        generatedPos= genType.SetPosition(generatedPos.y + generatedObjDist, value);
        GenerateBase();
    }

    /// <summary>
    /// 生成
    /// </summary>
    protected abstract void GenerateBase();
}
