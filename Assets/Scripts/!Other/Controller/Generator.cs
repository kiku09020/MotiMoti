using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DestroyerBase))]       // 削除コンポーネント必須にする
public class Generator : MonoBehaviour
{
    [Header("Object")]
    [SerializeField,Tooltip("生成するオブジェクト")] 
    protected GameObject genObj;
    protected Transform parent;                 // 生成先

    [SerializeField, Tooltip("生成基準のオブジェクト")]
    protected GameObject targetObj;

    [Header("Distance")]
    [SerializeField,Tooltip("生成されたオブジェクト同士の距離")]
    protected float genObjDist;
    [SerializeField, Tooltip("プレイヤーから生成位置の距離")]
    protected float targetDist;

    [Header("Position")]
    [SerializeField,Tooltip("生成位置の開始地点")] 
    protected Vector2 startGenPos;
    protected Vector2 genPos;                   // 生成位置

    [Header("Other")]
    [SerializeField, Tooltip("最大生成数")]
    protected int maxCnt;

    // list
    protected List<GameObject> genObjList = new List<GameObject>();     // 生成されたオブジェクトのリスト

    /* プロパティ */
    public List<GameObject> GenObjList => genObjList;
    public int MaxCnt => maxCnt;

	//-------------------------------------------------------------------
    protected virtual void Awake()
    {
        parent = transform;         // 生成先指定
        genPos = startGenPos;       // 最初の生成位置の指定
    }

    void FixedUpdate()
    {
        if (!GameManager.isResult) {
            var dist = DistanceCaluculator.CheckDistance(targetObj.transform.position, genPos);
            if (dist < targetDist) {
                Generate();
            }
        }
    }

//-------------------------------------------------------------------
    // Y座標のみ
    protected void SetGeneratePosition()
	{
        var y = genPos.y + genObjDist;

        genPos = new Vector2(0, y);
	}

    // 限られた場所にのみ
    protected void SetGeneratePosition(float range,bool containMinus)
    {
        var x = 0f;
        if (containMinus) {
            x = range * Expansion.GetRandomDirect();
        }

        else {
            x = range;
        }

        var y = genPos.y + genObjDist;
        genPos = new Vector2(x, y);
    }

    // X座標をランダムに指定する
    protected void SetGenerateRandomPosition(float range)
    {
        var x = Random.Range(-range, range);
        var y = genPos.y + genObjDist;

        genPos = new Vector2(x, y);
    }

    //-------------------------------------------------------------------
    // 生成呼び出し用
    protected virtual void Generate()
    {
        GenerateBase();
    }

    // 生成
    protected virtual GameObject GenerateBase()
	{
        SetGeneratePosition();      // 生成位置の指定

        var obj = Instantiate(genObj, genPos, Quaternion.identity, parent);   // インスタンス化
        genObjList.Add(obj);                                           // リストに追加

        return obj;
	}

    protected virtual GameObject GenerateBase(float xRange, bool isRandom = true)
    {
        if (isRandom) {
            SetGenerateRandomPosition(xRange);
        }

        else {
            SetGeneratePosition(xRange, true);
        }

        var obj = Instantiate(genObj, genPos, Quaternion.identity, parent);
        genObjList.Add(obj);

        return obj;
    }
}
