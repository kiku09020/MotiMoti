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
    Transform parent_game;


//-------------------------------------------------------------------
    void Start()
    {
        /* 初期化 */
        parent_game = CanvasManager.Texts.transform;
    }

//-------------------------------------------------------------------

    public void GenText()
	{
        Vector2 pos = Camera.main.WorldToScreenPoint(Vector2.zero);

        GameObject inst = Instantiate(textObj, pos, Quaternion.identity, parent_game);
        Destroy(inst, destTime);
	}
}
