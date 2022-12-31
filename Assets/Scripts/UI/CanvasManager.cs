using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour {
    /* 値 */
    static GameObject mainCanvas;
    static GameObject ctrlUI;
    static GameObject texts;
    static GameObject pauseUI;
    static GameObject cautionUI;
    static GameObject resultUI;

    static public GameObject Texts { get => texts; }
    static public GameObject CtrlUI { get => ctrlUI; }
    static public GameObject PauseUI { get => pauseUI; }
    static public GameObject CautionUI { get => cautionUI; }
    static public GameObject ResultUI { get => resultUI; }

    //-------------------------------------------------------------------
    void Awake()
    {
        /* オブジェクト取得 */
        mainCanvas = GameObject.Find("MainCanvas");

        texts = mainCanvas.transform.Find("Texts").gameObject;
        ctrlUI = mainCanvas.transform.Find("ControllerUI").gameObject;
        pauseUI = mainCanvas.transform.Find("PauseUI").gameObject;
        cautionUI = pauseUI.transform.Find("CautionUI").gameObject;
        resultUI = mainCanvas.transform.Find("ResultUI").gameObject;

        /* 初期化 */
        pauseUI.SetActive(false);
        resultUI.SetActive(false);
    }

    //-------------------------------------------------------------------
    // ポーズ
    static public void ActivatePauseUI(bool activate)
    {
        if (activate) {
            ctrlUI.SetActive(false);
            texts.SetActive(false);
            pauseUI.SetActive(true);
        }

        // ポーズ解除
		else {
            ctrlUI.SetActive(true);
            texts.SetActive(true);
            pauseUI.SetActive(false);
        }
    }

    // 警告表示
    static public void ActivateCautionUI(bool activate)
    {
        cautionUI.SetActive(activate);
    }

    // リザルト画面
    static public void ActivateResultUI(bool activate)
	{
        resultUI.SetActive(activate);
        texts.SetActive(!activate);
        ctrlUI.SetActive(!activate);
	}
}
