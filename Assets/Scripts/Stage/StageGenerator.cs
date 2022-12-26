using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    [Header("オブジェクト")]
    [SerializeField] Stage ground;

    [Header("生成関係")]
    [SerializeField] Transform genParent;       // parent
    [SerializeField] Vector2 startGenPos;       // 一番最初の生成位置
    [SerializeField] float genPosXRange;        // Xの範囲
    [SerializeField] float genPosYDist;         // Yの距離
    [SerializeField] int genObjsMaxCnt;         // 最大数

    Vector2 genPos;         // 生成位置

    [Header("もち関係")]
    [SerializeField] Moti.MotiController moti;
    [SerializeField] float motiMaxDist;         // もちとの最大距離

    List<Stage> stageObjs = new List<Stage>();        // オブジェクトのlist


//-------------------------------------------------------------------
    void Awake()
    {
        genPos = startGenPos;

		while (stageObjs.Count < 5) {
            SetGeneratePos();
            Generate();
		}
    }

    void FixedUpdate()
    {
        CheckMotiPos();
    }

//-------------------------------------------------------------------
    // もちの位置に合わせる
    void CheckMotiPos()
	{
        var motiDist = Vector2.Distance(moti.transform.position, genPos);       // 生成位置ともちとの距離

		if (motiDist > motiMaxDist&&stageObjs.Count<10) {
            SetGeneratePos();
            Generate();
		}
	}

    // 生成位置の指定
    void SetGeneratePos()
	{
        var genPosX = Random.Range(-genPosXRange, genPosXRange);
        var genPosY = genPos.y + genPosYDist;

        genPos = new Vector2(genPosX, genPosY);
	}

    // 生成本体
    void Generate()
	{
        var obj = Instantiate(ground, genPos, Quaternion.identity, genParent);     // 生成

        // 1つ前のオブジェクトを指定
		if (stageObjs?.Count > 0) {
            obj.PrevStage = stageObjs[stageObjs.Count - 1];
		}

        stageObjs.Add(obj);

        SetStagePosition(obj);
	}

    // 位置の調整
    void SetStagePosition(Stage obj)
	{
        
	}
}
