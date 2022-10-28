using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour {
    /* 値 */
    GameObject mainCanvas;
    GameObject ctrlUI;
    GameObject texts;
    GameObject pauseUI;
    GameObject cautionUI;

    public GameObject Texts { get => texts; }
    public GameObject CtrlUI { get => ctrlUI; }
    public GameObject PauseUI { get => pauseUI; }
    public GameObject CautionUI { get => cautionUI; }

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
    public void ActivatePauseUI()
    {
        ctrlUI.SetActive(false);
        texts.SetActive(false);
        pauseUI.SetActive(true);
    }

    // ポーズ解除
    public void ActivateUnpauseUI()
    {
        ctrlUI.SetActive(true);
        texts.SetActive(true);
        pauseUI.SetActive(false);
    }

    // 警告表示
    public void ActivateCautionUI()
    {
        cautionUI.SetActive(true);
    }

    // 警告解除
    public void ActivateUncautionUI()
    {
        cautionUI.SetActive(false);
    }
}
