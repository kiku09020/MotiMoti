using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotiLineController : MonoBehaviour
{
	/* 値 */
	[Header("Line")]
	[SerializeField] int middlePointCount;                  // 間の点の数

	[Header("Collision")]
	[SerializeField] float angleLimit;                      // 限界の角度

	[Header("長さ")]
	[SerializeField] float stretchableLength;				// 伸ばせる長さ
	float length;                                           // 現在の長さ

	// 限界点
	bool isLimit;                                           // 長さ限界か
	bool isLimitOnce;                                       // 限界点に到達した瞬間
	bool isSpring;											// ばねで伸びてるか

	/* 座標 */
	List<Vector3> positions = new List<Vector3>();          // 全ての座標

	Vector3 ownPos;                                         // 自分(子)の座標
	Vector3 parentPos;                                      // 親の座標

	/* 当たり判定用のRay */
	bool isRayHit;                                          // Rayに当たってるか
	bool hitOnce;                                           // 当たった瞬間
	bool isAngleOver;										// angleがlimitを過ぎたか

	Vector2 firstHitPos;									// 
	Vector2 parentVec;                                      // 自分->親
	Vector2 hitVec;											// 自分->当たったオブジェクト
	float hitAngle;											// parentVecとfirstHitPosの角度

	int layerMask;                                          // ステージのみに衝突させるためのやつ

	/* コンポーネント取得用 */
	LineRenderer line;
	SpringJoint2D spring;

	Moti moti;

	/* プロパティ */
	// Ray
	public bool IsRayHit => isRayHit;
	public bool IsAngleOver => isAngleOver;

	public Vector2 ParentVec => parentVec;
	public float HitAngle => hitAngle;

	// 長さ
	public float Length => length;
	public float StretchableLenth { get => stretchableLength; set => stretchableLength = value; }

	// 限界点
	public bool IsLimit => isLimit;
	public bool IsSpring => isSpring;

	//-------------------------------------------------------------------
	void Start()
	{
		/* コンポーネント取得 */
		line = GetComponent<LineRenderer>();
		spring = transform.parent.GetComponent<SpringJoint2D>();

		moti = transform.parent.GetComponent<Moti>();

		LineSetUp();

		layerMask = LayerMask.GetMask("StageLayer");
	}

	// 初期化
	public void Init()
    {
		length = 0;
		hitAngle = 0;

		ownPos = Vector2.zero;
		parentPos = Vector2.zero;
		firstHitPos = Vector2.zero;
		hitVec = Vector2.zero;
		parentVec = Vector2.zero;

		isLimit = false;
		isLimitOnce = false;
		isSpring = false;
		isAngleOver = false;
		isRayHit = false;
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
	}

	// 更新
	public void LineUpdate()
	{
		// 各位置を更新
		SetPos();

		positions[0] = ownPos;
		positions[middlePointCount + 1] = parentPos;

		line.SetPositions(positions.ToArray());         // LineRendererにセット

		line.widthMultiplier = transform.parent.localScale.x / 4;   // 線の太さの指定

		LineRay();
		CheckAngle();
		CheckLength();

		Spring();
	}

	//-------------------------------------------------------------------
	// 座標の指定
	void SetPos()
	{
		ownPos = transform.parent.position;				// 子(自分)

		var parent = moti.Family.Parent;

        if (parent) {
			parentPos = parent.transform.position;		// 親
        }

        else {
			parentPos = ownPos;							// 親がいない場合、自分の座標
        }
	}

	//-------------------------------------------------------------------
	// 子から親へのRayの処理
	void LineRay()
    {
		if (moti.Family.ExistParent) {
			var vec = parentPos - ownPos;									// ベクトル(親 - 自分)
			var rad = transform.parent.localScale.x / 2 * vec.normalized;   // 半径
			parentVec = (parentPos - rad) - (ownPos + rad);

			// Ray
			var origin = ownPos + rad;
			var parentRay = new Ray2D(origin, parentVec);
			Debug.DrawRay(origin, parentVec,Color.black);

			// Raycast
			var hit = Physics2D.Raycast(origin, parentRay.direction, parentVec.magnitude, layerMask);

			// Collision
			if (hit ) {
				LineRayCollision(hit);

				isRayHit = true;
            }

            else {
				isRayHit = false;
				hitOnce = false;
				isAngleOver = false;

				firstHitPos = ownPos;       // hitPos戻す
				hitAngle = 0;				// 角度戻す
            }
		}
	}

	// Raycastに触れたときの処理
	void LineRayCollision(RaycastHit2D hit)
    {
		var col = hit.collider;

		// 触れた瞬間
        if (!hitOnce) {
			hitOnce = true;
			firstHitPos = hit.point;
        }

		if (col.tag == "Stage") {
			print(col);
		}

		hitVec = moti.CheckVector(firstHitPos);             // 自分→hitPos
		hitAngle = Vector2.Angle(parentVec, hitVec);        // 角度求める
	}

	//-------------------------------------------------------------------
	// 角度のチェック
	void CheckAngle()
    {
		isAngleOver = (hitAngle > angleLimit) ? true : false;
    }

	// 長さのチェック
	void CheckLength()
	{
		// 長さ
		length = Vector2.Distance(ownPos, parentPos);
		print(Length);

		// フラグ
		isLimit = (length > stretchableLength) ? true : false;

        if (isLimit) {
            if (!isLimitOnce) {
				isLimitOnce = true;
            }
        }

        else {
			isLimitOnce = false;
        }
	}

	void Spring()
    {
        if (isLimit) {
			if (isLimitOnce) {
				isSpring = true;

				spring.enabled = true;
				spring.connectedBody = moti.Family.Parent.RB;
			}
        }
		
        else {
			spring.enabled = false;
			spring.connectedBody = null;
        }
		
    }
}
