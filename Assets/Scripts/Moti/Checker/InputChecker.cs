using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti
{
	public class InputChecker : MonoBehaviour
	{
		/* フラグ */
		bool isTapping;             // タップ中
		bool isDraging;             // ドラッグ中(タップ中にマウスが動いているとき)
		bool isOnMoti;              // マウスがもちの上にいるか

		/* 値 */
		float mouseDistance;

		static Vector2 clickedPos;          // クリックした座標
		static Vector2 mousePos;            // マウス位置(スクリーン座標)
		static Vector2 mousePosWorld;       // マウス位置(ワールド座標)

		/* プロパティ */
		public bool IsTapping => isTapping;
		public bool IsDraging => isDraging;
		public bool IsOnMoti => isOnMoti;

		public static Vector2 MousePos => mousePos;
		public static Vector2 MousePosWorld => mousePosWorld;
		public float MouseDistance => mouseDistance;

		//-------------------------------------------------------------------
		void Update()
		{
			// マウス座標更新
			mousePos = Input.mousePosition;
			mousePosWorld = Camera.main.ScreenToWorldPoint(mousePos);

			mouseDistance = Vector2.Distance(mousePosWorld, transform.position);
		}

		//-------------------------------------------------------------------
		/* EventTrigger用の関数 */

		// ポインターが範囲内に入った時
		public void PointerEnter()
		{
			isOnMoti = true;
		}

		// ポインターが範囲外に出たとき
		public void PointerExit()
		{
			isOnMoti = false;
		}

		// タップした瞬間
		public void TapDown()
		{
			isTapping = true;
			clickedPos = mousePosWorld;         // クリックした座標の指定
		}

		// タップ離した瞬間
		public void TapUp()
		{
			isTapping = false;
			isDraging = false;
		}

		// ドラッグしている間
		public void Drag()
		{
			isDraging = true;
		}

		// ドラッグ止めた時
		public void DragEnd()
		{
			isDraging = false;
		}

		//-------------------------------------------------------------------
	}
}