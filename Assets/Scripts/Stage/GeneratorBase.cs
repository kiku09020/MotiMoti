using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorBase : MonoBehaviour
{
    [Header("GenerateObject")]
    [SerializeField] protected GameObject generatedObj;         // 生成オブジェクト
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
    protected List<GameObject> genObjs = new List<GameObject>();

    /* プロパティ */
    public List<GameObject> GenObjects => genObjs;
    public static GameObject TargetObj => targetObj;
    public int MaxCnt => maxCnt;

	//-------------------------------------------------------------------
    protected virtual void Awake()
    {
        targetObj = GameObject.Find("Moti");
        genPos = startGenPos;

		while (genObjs.Count < maxCnt) {
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

    // 生成
    protected virtual void Generate()
	{
        SetGeneratePosition();      // 生成位置の指定

        var obj = Instantiate(generatedObj, genPos, Quaternion.identity, parent);   // インスタンス化
        genObjs.Add(obj);                                                           // リストに追加
	}
}
