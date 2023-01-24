using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti {
	public class MotiLineController : MonoBehaviour
	{
		/* 値 */
		[Header("長さ")]
		[SerializeField] float stretchableLength;               // 伸ばせる長さ
		float length;                                           // 現在の長さ

		// 限界点
		bool isLengthLimit;                                     // 長さ限界か
		bool isLimitOnce;                                       // 限界点に到達した瞬間

		/* 座標 */
		Vector3[] positions = new Vector3[2];					// 全ての座標

		Vector3 ownPos;                                         // 親(自分)の座標
		Vector3 childPos;										// 子の座標

		Vector2 familyVec;										// 親->子

		/* コンポーネント取得用 */
		LineRenderer line;

		MotiController moti;

		/* プロパティ */
		public Vector2 FamilyVec => familyVec;

		// 長さ
		public float Length => length;
		public float StretchableLenth { get => stretchableLength; set => stretchableLength = value; }

		// 限界点
		public bool IsLengthLimit => isLengthLimit;

		public Vector3[] Positions => positions;
		public float Width { get; private set; }

		//-------------------------------------------------------------------
		void Start()
		{
			/* コンポーネント取得 */
			line = GetComponent<LineRenderer>();

            moti = transform.parent.GetComponent<MotiController>();

			LineSetUp();
		}

		// 初期化
		public void Init()
		{
			length = 0;

			ownPos = Vector2.zero;
			childPos = Vector2.zero;
			familyVec = Vector2.zero;

			isLengthLimit = false;
			isLimitOnce = false;
		}

		//-------------------------------------------------------------------
		// はじめにする処理
		public void LineSetUp()
		{
			SetPos();

			line.positionCount = 2;					// 点の数指定
			line.numCapVertices = 10;               // 角丸
		}

		// 更新
		public void LineUpdate()
		{
			// 各位置を更新
			SetPos();

			line.SetPositions(positions);         // LineRendererにセット

			Width = line.widthMultiplier = transform.parent.localScale.x * 1.25f;   // 線の太さの指定

			if (moti.Family.HasChild) {
				CheckLength();
			}
		}

		//-------------------------------------------------------------------
		// 座標の指定
		void SetPos()
		{
			ownPos = transform.parent.position;             // 子(自分)

			if (moti.Family.HasChild) {
				var child = moti.Family.OtherMoti;
				childPos = child.transform.position;      // 親
			}

			else {
				childPos = ownPos;                         // 親がいない場合、自分の座標
			}

			positions[0] = ownPos;
			positions[1] = childPos;
		}

		//-------------------------------------------------------------------
		// 長さのチェック
		void CheckLength()
		{
			// 長さ
			length = Vector2.Distance(ownPos, childPos);

			// フラグ
			isLengthLimit = (length >= stretchableLength-0.1f) ? true : false;
			isLimitOnce = (isLengthLimit && !isLimitOnce) ? true : false;

			Debug.DrawLine(ownPos, childPos,Color.black);
		}
	}
}