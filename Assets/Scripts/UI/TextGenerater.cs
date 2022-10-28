using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextGenerater : MonoBehaviour
{
    /* 値 */
    [SerializeField] float destTime;        // 削除までの時間

    /* フラグ */


    /* テキスト */
    [SerializeField] GameObject textObj;

    /* 親 */
    Transform prnt_game;

    /* コンポーネント取得用 */
    CanvasManager canvas;


//-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */


        /* コンポーネント取得 */
        canvas = GetComponent<CanvasManager>();

        /* 初期化 */
        prnt_game = canvas.GameCnvs.transform;
    }

//-------------------------------------------------------------------

    public void GenText()
	{
        Vector2 pos = Camera.main.WorldToScreenPoint(Vector2.zero);

        GameObject inst = Instantiate(textObj, pos, Quaternion.identity, prnt_game);
        Destroy(inst, destTime);
	}
}
