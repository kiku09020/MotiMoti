using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeMoti : MonoBehaviour
{
    /* 値 */
    [SerializeField] float thickness;       // 端の太さ

    /* コンポーネント取得用 */



//-------------------------------------------------------------------
    void Awake()
    {
        /* オブジェクト取得 */


        /* コンポーネント取得 */


        /* 初期化 */
        SetScaler();
    }

    // 大きさ調整
    void SetScaler()
	{
        Vector2 parentScale = transform.parent.localScale;
        Vector2 targetScale;

        // 縦長
		if (parentScale.x < parentScale.y) {
            targetScale = new Vector2(thickness, 1);
		}

		// 横長
		else {
            targetScale = new Vector2(1, thickness);
		}

        transform.localScale = targetScale;
	}
}
