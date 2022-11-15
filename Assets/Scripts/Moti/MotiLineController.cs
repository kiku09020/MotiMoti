using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotiLineController : MonoBehaviour
{
	/* 値 */
	[SerializeField] int middlePointCount;					// 間の点の数

	List<Vector3> positions = new List<Vector3>();          // 全ての座標
	List<Vector2> pos2D = new List<Vector2>();              // 座標(2D)

	Vector3 ownPos;                                         // 自分の座標
	Vector3 clonePos;                                       // クローンの座標

	/* コンポーネント取得用 */
	LineRenderer line;
	EdgeCollider2D col;

	Ray2D ray;

	Moti moti;

	//-------------------------------------------------------------------
	void Start()
	{
		/* オブジェクト取得 */


		/* コンポーネント取得 */
		line = GetComponent<LineRenderer>();
		col = GetComponent<EdgeCollider2D>();

		moti = transform.parent.GetComponent<Moti>();

		LineSetUp(moti.Stretcher.Clone);
	}

	private void FixedUpdate()
	{
		LineUpdate(moti.Stretcher.Clone);
	}

	//-------------------------------------------------------------------
	// はじめにする処理
	public void LineSetUp(Moti cloneMoti)
	{
		// 端の座標
		SetPos(cloneMoti);

		positions.Add(ownPos);                                      // 自分の位置を追加
		positions.Add(clonePos);                                    // クローンの位置を追加

		line.positionCount = middlePointCount + 2;					// 点の数指定
		line.SetPositions(positions.ToArray());                     // LineRendererにセット

		line.numCapVertices = 10;                                   // 角丸
		line.widthMultiplier = transform.parent.localScale.x / 2;   // 線の太さの指定
	}

	// 更新
	public void LineUpdate(Moti cloneMoti)
	{
		// 各位置を更新
		SetPos(cloneMoti);

		positions[0] = ownPos;
		positions[middlePointCount + 1] = clonePos;

		line.SetPositions(positions.ToArray());             // LineRendererにセット

		LineCollision();                                    // 当たり判定
	}

	// 終了時の処理
	public void LineExit()
	{
		line.positionCount = 0;
	}

	// 座標の指定
	void SetPos(Moti clone)
	{
		ownPos = transform.position;

		if (clone) {
			clonePos = clone.transform.position;
		}

		else {
			clonePos = ownPos;
		}
	}

	// 当たり判定
	void LineCollision()
	{
		ray = new Ray2D(ownPos, clonePos - ownPos);
		Debug.DrawRay(ownPos, ray.direction, Color.red);

		col.SetPoints(pos2D);
	}
}
