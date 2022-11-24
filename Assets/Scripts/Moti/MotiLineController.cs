using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotiLineController : MonoBehaviour
{
	/* 値 */
	[SerializeField] int middlePointCount;					// 間の点の数

	List<Vector3> positions = new List<Vector3>();          // 全ての座標

	Vector3 ownPos;                                         // 自分(子)の座標
	Vector3 parentPos;                                      // 親の座標

	/* 当たり判定用のRay */
	bool isRayHit;											// Rayに当たってるか

	Vector3 radVec;											// 半径分のベクトル
	Ray2D targetRay;										// もち→マウスのRay
	int layerMask;											// ステージのみに衝突させるためのやつ

	/* コンポーネント取得用 */
	LineRenderer line;
	EdgeCollider2D col;

	Moti moti;

	//-------------------------------------------------------------------
	void Start()
	{
		/* コンポーネント取得 */
		line = GetComponent<LineRenderer>();
		col = GetComponent<EdgeCollider2D>();

		moti = transform.parent.GetComponent<Moti>();

		LineSetUp();

		layerMask = LayerMask.GetMask("StageLayer");

	}

	//-------------------------------------------------------------------
	// はじめにする処理
	public void LineSetUp()
	{
		SetPos();

		positions.Add(ownPos);                                      // 自分の位置を追加
		positions.Add(parentPos);                                   // 親の位置を追加

		line.positionCount = middlePointCount + 2;					// 点の数指定
		line.SetPositions(positions.ToArray());                     // LineRendererにセット

		line.numCapVertices = 10;                                   // 角丸
		line.widthMultiplier = transform.parent.localScale.x / 2;   // 線の太さの指定
	}

	// 更新
	public void LineUpdate()
	{
		// 各位置を更新
		SetPos();

		positions[0] = ownPos;
		positions[middlePointCount + 1] = parentPos;

		line.SetPositions(positions.ToArray());             // LineRendererにセット

		LineRay();
	}

	// 座標の指定
	void SetPos()
	{
		ownPos = transform.parent.position;					// 子(自分)

		var parent = moti.Family.Parent;

        if (parent) {
			parentPos = parent.transform.position;		// 親
        }

        else {
			parentPos = ownPos;							// 親がいない場合、自分の座標
        }
	}

	void LineRay()
    {
		if (moti.Family.ExistParent) {
			var vec = parentPos - ownPos;									// ベクトル(親 - 自分)
			var rad = transform.parent.localScale.x / 2 * vec.normalized;   // 半径
			var radVec = (parentPos - rad) - (ownPos + rad);

			// Ray
			var origin = ownPos + rad;
			targetRay = new Ray2D(origin, radVec);
			Debug.DrawRay(targetRay.origin, radVec,Color.black);

			// Raycast
			
		}
	}
}
