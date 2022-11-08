using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputChecker : MonoBehaviour
{
    /* 値 */
    bool isTapping;

	/* プロパティ */
	public bool IsTapping => isTapping;

	/* コンポーネント取得用 */


	//-------------------------------------------------------------------
	private void Update()
	{
		// 離されたらfalse
		if(Input.GetMouseButtonUp(0)){
			isTapping = false;
		}

		print(isTapping);
	}

	// クリック時の処理
	public void Clicked()
    {
        isTapping = true;
	}
}
