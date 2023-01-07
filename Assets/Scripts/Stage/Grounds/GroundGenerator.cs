using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : GeneratorBase
{
	[Header("DerivedClass")]	/* 派生クラスのパラメータ */
    [SerializeField] float genPosXRange;        // Xの範囲

	[Header("TargetObject")]	/* プレイヤーオブジェクト格納用 */
    [SerializeField] GameObject _targetObj;

	/* プロパティ */
	public float GenObjDist => genObjDist;		// オブジェクト同士の距離

	//-------------------------------------------------------------------
	protected override void Awake()
	{
		targetObj = _targetObj;

		base.Awake();
	}

	// 生成本体
	protected override void Generate()
	{
        SetGeneratePosition(genPosXRange);      // 生成位置

        var obj = Instantiate(generatedObj, genPos, Quaternion.identity, parent);     // 生成

        // 1つ前のオブジェクトを指定
		if (genObjs?.Count > 0) {
            obj.GetComponent<Ground>().PrevStage = genObjs[genObjs.Count - 1].GetComponent<Ground>();
		}

        genObjs.Add(obj);
	}
}
