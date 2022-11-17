using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputChecker : MonoBehaviour
{
    /* 値 */
    bool isTapping;		// タップ中
	bool isDraging;     // ドラッグ中(動いているとき)
	bool isInTapped;    // 範囲内で離されたとき
	bool isOnMoti;		// マウスがもちの上にいるか

	float dragDistance;		// ドラッグ距離

	Vector2 clickedPos;			// クリックした座標
	Vector2 mousePos;			// マウス位置(スクリーン座標)
	Vector2 mousePosWorld;      // マウス位置(ワールド座標)

	/* プロパティ */
	public bool IsTapping => isTapping;
	public bool IsDraging => isDraging;
	public bool IsInTapped { get => isInTapped; set => isInTapped = value; }
	public bool IsOnMoti => isOnMoti;

	public float DragDistance => dragDistance;

	public Vector2 MousePos => mousePos;
	public Vector2 MousePosWorld => mousePosWorld;

	/* コンポーネント取得用 */


	//-------------------------------------------------------------------
	private void Update()
	{
		mousePos = Input.mousePosition;
		mousePosWorld = Camera.main.ScreenToWorldPoint(mousePos);
	}

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
		clickedPos = mousePosWorld;			// クリックした座標の指定
	}

	// タップ離した瞬間
	public void TapUp()
	{
		isTapping = false;
		isDraging = false;
	}

	// タップしてもち内で離した瞬間
	public void Clicked()
	{
		isInTapped = true;
	}

	// ドラッグしている間
	public void Drag()
	{
		isDraging = true;
		dragDistance = Vector2.Distance(clickedPos, MousePosWorld);      // ドラッグ距離
	}

	// ドラッグ止めた時
	public void DragEnd()
	{
		isDraging = false;
		dragDistance = 0;
	}
}
