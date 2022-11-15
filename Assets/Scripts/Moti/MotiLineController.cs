using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotiLineController : MonoBehaviour
{
	/* 値 */
	[SerializeField] int middlePointCount;					// 間の点の数

	List<Vector3> positions = new List<Vector3>();          // 全ての座標
	List<Vector2> pos2D = new List<Vector2>();              // 座標(2D)

	Vector3 ownPos;                                         // 自分(子)の座標
	Vector3 parentPos;                                      // 親の座標

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

		LineSetUp();
	}

	private void FixedUpdate()
	{
		LineUpdate();
	}

	//-------------------------------------------------------------------
	// はじめにする処理
	public void LineSetUp()
	{
		SetPos();

		positions.Add(ownPos);                                      // 自分の位置を追加
		positions.Add(ownPos);									// 親の位置を追加

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

	// 終了時の処理
	public void LineExit()
	{
		line.positionCount = 0;
	}

	// 座標の指定
	void SetPos()
	{
		ownPos = transform.position;                                // 子(自分)

		var parent = moti.Family.Parent;

        if (parent) {
			parentPos = parent.transform.position;			// 親
        }

        else {
			parentPos = ownPos;
        }
	}

	// 当たり判定
	void LineCollision()
	{
		ray = new Ray2D(ownPos, parentPos - ownPos);

		Debug.DrawRay(ownPos, ray.direction, Color.red);
		Debug.DrawRay(ownPos, parentPos, Color.yellow);

		col.SetPoints(pos2D);
	}
}
