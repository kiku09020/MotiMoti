using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputChecker : MonoBehaviour
{
	/* フラグ */
    bool isTapping;				// タップ中
	bool isDraging;				// ドラッグ中(タップ中にマウスが動いているとき)
	bool isInTapped;			// 範囲内で離されたとき
	bool isOnMoti;				// マウスがもちの上にいるか

    /* 値 */
	float dragDistance;			// ドラッグ距離

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

	//-------------------------------------------------------------------
	void Update()
	{
		// マウス座標更新
		mousePos = Input.mousePosition;
		mousePosWorld = Camera.main.ScreenToWorldPoint(mousePos);
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
		dragDistance = Vector2.Distance(clickedPos, mousePosWorld);      // ドラッグ距離
	}

	// ドラッグ止めた時
	public void DragEnd()
	{
		isDraging = false;
		dragDistance = 0;
	}

	//-------------------------------------------------------------------
	// 目標のオブジェクトの座標とマウスのベクトルを調べる
	public Vector2 CheckMousePosDistance(Vector2 targetPos)
    {
		var vector = targetPos - mousePosWorld;
		Debug.DrawRay(mousePosWorld, vector, Color.blue);

		return vector;
    }
}
