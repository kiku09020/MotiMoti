using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotiLineController : MonoBehaviour
{
	/* 値 */
	[SerializeField] int middlePointCount;					// 間の点の数

	List<Vector3> positions = new List<Vector3>();          // 全ての座標
	List<Vector2> colPoints = new List<Vector2>();          // 当たり判定用の座標

	Vector3 ownPos;                                         // 自分(子)の座標
	Vector3 parentPos;                                      // 親の座標

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
	}

	//-------------------------------------------------------------------
	// はじめにする処理
	public void LineSetUp()
	{
		SetPos();

		positions.Add(ownPos);                                      // 自分の位置を追加
		positions.Add(parentPos);                                   // 親の位置を追加

		colPoints.Add(Vector2.zero);
		colPoints.Add(Vector2.zero);

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

		LineCollision();                                    // 当たり判定
	}

	// 座標の指定
	void SetPos()
	{
		ownPos = transform.position;					// 子(自分)

		var parent = moti.Family.Parent;

        if (parent) {
			parentPos = parent.transform.position;		// 親
        }

        else {
			parentPos = ownPos;							// 親がいない場合、自分の座標
        }
	}

	// 当たり判定
	void LineCollision()
	{
		if (positions?.Count > 0) {
			colPoints[1] = transform.InverseTransformPoint(parentPos);		// 親の座標をローカル座標に変換

			col.SetPoints(colPoints);                                       // 点の座標を指定する
			col.edgeRadius = 0.32f;
		}
	}
}
