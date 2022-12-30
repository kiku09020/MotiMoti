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

    static public GameObject Texts { get => texts; }
    static public GameObject CtrlUI { get => ctrlUI; }
    static public GameObject PauseUI { get => pauseUI; }
    static public GameObject CautionUI { get => cautionUI; }

    //-------------------------------------------------------------------
    void Awake()
    {
        /* オブジェクト取得 */
        mainCanvas = GameObject.Find("MainCanvas");

        texts = mainCanvas.transform.Find("Texts").gameObject;
        ctrlUI = mainCanvas.transform.Find("ControllerUI").gameObject;
        pauseUI = mainCanvas.transform.Find("PauseUI").gameObject;
        cautionUI = pauseUI.transform.Find("CautionUI").gameObject;

        /* 初期化 */
        pauseUI.SetActive(false);
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
}
