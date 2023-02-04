using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator_old : Generator
{
	[Header("Range")]	
    [SerializeField] float genPosXRange;        // Xの範囲
	[SerializeField] float randRotStartHeight;	// ランダム回転開始高度

	/* プロパティ */
	public float GenObjDist => genObjDist;      // オブジェクト同士の距離

	//-------------------------------------------------------------------
	Quaternion SetGenerateRotation()
	{
		// 特定の高度以上は、床を回転させる
		if (genPos.y > randRotStartHeight) {
			var rand = Random.Range(0, 360);
			return Quaternion.Euler(0, 0, rand);
		}

		// 通常角度
		return Quaternion.identity;
	}

	// 生成本体
	protected override GameObject GenerateBase()
	{
        SetGenerateRandomPosition(genPosXRange);      // 生成位置

        var obj = Instantiate(genObj, genPos, SetGenerateRotation(), parent);     // 生成

        // 1つ前のオブジェクトを指定
		if (genObjList?.Count > 0) {
            obj.GetComponent<Ground>().PrevStage = genObjList[genObjList.Count - 1].GetComponent<Ground>();
		}

        genObjList.Add(obj);

		return obj;
	}
}
