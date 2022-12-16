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
		bool isLimit;                                           // 長さ限界か
		bool isLimitOnce;                                       // 限界点に到達した瞬間

		/* 座標 */
		Vector3[] positions = new Vector3[2];					// 全ての座標

		Vector3 ownPos;                                         // 子(自分)の座標
		Vector3 parentPos;                                      // 親の座標

		Vector2 parentVec;                                      // 子->親

		/* コンポーネント取得用 */
		LineRenderer line;

		MotiController moti;

		/* プロパティ */
		public Vector2 ParentVec => parentVec;

		// 長さ
		public float Length => length;
		public float StretchableLenth { get => stretchableLength; set => stretchableLength = value; }

		// 限界点
		public bool IsLimit => isLimit;

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
			parentPos = Vector2.zero;
			parentVec = Vector2.zero;

			isLimit = false;
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

			positions[0] = ownPos;
			positions[1] = parentPos;

			line.SetPositions(positions);         // LineRendererにセット

			line.widthMultiplier = transform.parent.localScale.x / 4;   // 線の太さの指定

			CheckLength();
		}

		//-------------------------------------------------------------------
		// 座標の指定
		void SetPos()
		{
			ownPos = transform.parent.position;             // 子(自分)

			var parent = moti.Family.Parent;

			if (parent) {
				parentPos = parent.transform.position;      // 親
			}

			else {
				parentPos = ownPos;                         // 親がいない場合、自分の座標
			}
		}

		//-------------------------------------------------------------------
		// 長さのチェック
		void CheckLength()
		{
			// 長さ
			length = Vector2.Distance(ownPos, parentPos);

			// フラグ
			isLimit = (length > stretchableLength) ? true : false;
			isLimitOnce = (isLimit && !isLimitOnce) ? true : false;
		}
	}
}