using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectSetter : MonoBehaviour
{
    /* 値 */
    [SerializeField] Vector2 targAspect;

    /* フラグ */


    /* プロパティ */


    /* コンポーネント取得用 */
    Camera cam;



//-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */


        /* コンポーネント取得 */


        /* 初期化 */
        cam = GetComponent<Camera>();

        SetAspect();
    }

//-------------------------------------------------------------------

    void SetAspect()
	{
        var scrnAsp = Screen.width / (float)Screen.height;
        var targAsp = targAspect.x / targAspect.y;

        var rate = targAsp / scrnAsp;
        var rect = new Rect(0, 0, 1, 1);

        if (rate < 1) {
            rect.width = rate;
            rect.x = 0.5f - rect.width * 0.5f;
        }
        else {
            rect.height = 1 / rate;
            rect.y = 0.5f - rect.height * 0.5f;
        }


        cam.rect = rect;
    }
}
