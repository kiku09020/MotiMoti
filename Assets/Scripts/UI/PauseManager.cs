using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    /* 値 */
    bool isPause;
    public bool isRetry;
    public bool isExit;

    public bool IsPause { get => isPause; set => isPause = value; }

    /* 文字列 */
    string cautTxt;
    [SerializeField] string cautTxtConfirm;         // 警告テキストの確認箇所の文字列

    /* コンポーネント取得用 */
    CanvasManager canvas;

//-------------------------------------------------------------------
    void Start()
    {
        /* オブジェクト取得 */
        GameObject uiObj = transform.Find("UIManager").gameObject;

        /* コンポーネント取得 */
        canvas = uiObj.GetComponent<CanvasManager>();

        /* 初期化 */
        cautTxt = canvas.CautionUI.transform.Find("Back/Text").GetComponent<Text>().text;
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
        canvas.CautionUI.transform.Find("Back/Text").GetComponent<Text>().text = cautTxt;
    }
}
