using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DestroyerBase))]       // 削除コンポーネント必須にする
public class GeneratorBase : MonoBehaviour
{
    const float dispSpace = 10;

    [Header("GenerateObject")]
    [SerializeField,Tooltip("生成するオブジェクト")] 
    protected GameObject genObj;
    [SerializeField,Tooltip("生成先のparent")]
    protected Transform parent;

    [Space(dispSpace)]
    [SerializeField,Tooltip("生成されたオブジェクト同士の距離")]
    protected float genObjDist;
    [SerializeField,Tooltip("最大生成数")]
    protected int maxCnt;

    // position
    [Space(dispSpace)]
    [SerializeField,Tooltip("生成位置の開始地点")] 
    protected Vector2 startGenPos;
    protected Vector2 genPos;                                   // 生成位置

    // target
    [Space(dispSpace)]
    [SerializeField,Tooltip("プレイヤーから生成位置の距離")] 
    protected float targetDist;
    protected static GameObject targetObj;                      // プレイヤー(Groundから代入)

    // list
    protected List<GameObject> genObjList = new List<GameObject>();     // 生成されたオブジェクトのリスト

    /* プロパティ */
    public List<GameObject> GenObjList => genObjList;
    public static GameObject TargetObj => targetObj;
    public int MaxCnt => maxCnt;

	//-------------------------------------------------------------------
    protected virtual void Awake()
    {
        targetObj = GameObject.Find("Moti");
        genPos = startGenPos;

		while (genObjList.Count < maxCnt) {
            Generate();
		}

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
    protected virtual void SetGeneratePosition()
	{
        var y = genPos.y + genObjDist;

        genPos = new Vector2(0, y);
	}

    // X座標をランダムに指定する
    protected virtual void SetGeneratePosition(float xRange)
	{
        var x = Random.Range(-xRange, xRange);
        var y = genPos.y + genObjDist;

        genPos = new Vector2(x, y);
	}

    //-------------------------------------------------------------------

    // 生成
    protected virtual void Generate()
	{
        SetGeneratePosition();      // 生成位置の指定

        var obj = Instantiate(genObj, genPos, Quaternion.identity, parent);   // インスタンス化
        genObjList.Add(obj);                                           // リストに追加
	}

    protected virtual GameObject Generate(float xRange)
    {
        SetGeneratePosition(xRange);

        var obj = Instantiate(genObj, genPos, Quaternion.identity, parent);
        genObjList.Add(obj);

        return obj;
    }
}
