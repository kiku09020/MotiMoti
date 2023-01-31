using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : SimpleSingleton<PauseManager>
{
    /* 値 */
    bool isPause;
    public bool isRetry;
    public bool isExit;

    public bool IsPause { get => isPause; set => isPause = value; }

    /* 文字列 */
    Text cautTxt;
    [SerializeField] string cautTxtConfirm;         // 警告テキストの確認箇所の文字列

    /* コンポーネント */

//-------------------------------------------------------------------
    void Start()
    {
        /* 初期化 */
        cautTxt = CanvasManager.CautionUI.transform.Find("Back/Text").GetComponent<Text>();
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

        var text = reasonTxt + "\n" + cautTxtConfirm;
        cautTxt.text = text;
    }

    public void ResetFlags()
	{
        isPause = false;
        isRetry = false;
        isExit = false;
	}
}
