using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputChecker : MonoBehaviour
{
	/* 値 */
	static Vector2 clickedPos;          // クリックした座標
	static Vector2 clickedPosWorld;

	static Vector2 mousePos;            // マウス位置(スクリーン座標)
	static Vector2 mousePosWorld;       // マウス位置(ワールド座標)

	/* プロパティ */
	public static bool IsTapping { get; private set; }

	public static float MouseDistance { get; private set; }
	public static Vector3 MouseVector { get; private set; }

    //-------------------------------------------------------------------
    private void Awake()
    {
		clickedPos = Vector2.zero;
		clickedPosWorld = Vector2.zero;
		mousePos = Vector2.zero;
		mousePosWorld = Vector2.zero;

		IsTapping = false;
		MouseDistance = 0;
		MouseVector = Vector2.zero;
    }

    void Update()
	{
		// クリック座標
		if (Input.GetMouseButtonDown(0)) {
			IsTapping = true;

			clickedPos = Input.mousePosition;
			clickedPosWorld = Camera.main.ScreenToWorldPoint(clickedPos);
		}

		// マウス座標更新
        if (Input.GetMouseButton(0)) {
			mousePos = Input.mousePosition;
			mousePosWorld = Camera.main.ScreenToWorldPoint(mousePos);

			MouseDistance = Vector2.Distance(clickedPosWorld,mousePosWorld);
			MouseVector = mousePosWorld - clickedPosWorld;

			Debug.DrawLine(clickedPosWorld,mousePosWorld);

			print(MouseDistance);
		}

		// 離した瞬間
        if (Input.GetMouseButtonUp(0)) {
			IsTapping = false;
        }
	}

	//-------------------------------------------------------------------
}