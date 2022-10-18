using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : ButtonManager
{
    /* 値 */
    public bool isRetry;
    public bool isExit;

    /* 文字列 */
    string cautTxt;
    [SerializeField] string cautTxtConfirm;         // 警告テキストの確認箇所の文字列

    /* コンポーネント取得用 */
    CanvasManager _canvas;

//-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */
        GameObject uiObj = transform.Find("UIManager").gameObject;

        /* コンポーネント取得 */
        _canvas = uiObj.GetComponent<CanvasManager>();

        /* 初期化 */
        cautTxt = _canvas.CautCnvs.transform.Find("Back/Text").GetComponent<Text>().text;
    }

    //-------------------------------------------------------------------
    void FixedUpdate()
    {
        
    }

//-------------------------------------------------------------------
    // 注意書きの指定
    public void SetCaution()
    {
        string reasonTxt = "";

        if (isRetry) {
            reasonTxt = "初めからやり直します。";
        }

        else if (isExit) {
            reasonTxt = "ゲームを終了します。";
        }

        cautTxt = reasonTxt + "\n" + cautTxtConfirm;
        _canvas.CautCnvs.transform.Find("Back/Text").GetComponent<Text>().text = cautTxt;
    }
}
