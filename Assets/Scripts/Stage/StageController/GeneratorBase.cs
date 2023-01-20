using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DestroyerBase))]       // 削除コンポーネント必須にする
public class GeneratorBase : MonoBehaviour
{
    [Header("GenerateObject")]
    [SerializeField] protected GameObject genObj;               // 生成オブジェクト
    [SerializeField] protected Transform parent;                // 生成するparent

    [Space(10)]
    [SerializeField] protected float genObjDist;                // オブジェクト同士の距離
    [SerializeField] protected int maxCnt;                      // オブジェクトの最大数

    // position
    [Space(10)]
    [SerializeField] protected Vector2 startGenPos;             // 最初の生成位置
    protected Vector2 genPos;                                   // 生成位置

    // target
    [Space(10)]
    [SerializeField] protected float targetObjMaxDist;          // プレイヤーから生成位置の最大距離
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
            if (dist < targetObjMaxDist) {
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
