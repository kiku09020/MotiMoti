using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    /* 値 */

    [Header("Objects")]
    [SerializeField] GameObject mainCnvsPrfb;     // メインのキャンバス

    GameObject mainCnvsInst;      // インスタンス

    GameObject ctrlCnvs;
    GameObject gameUICnvs;
    GameObject pauseCnvs;
    GameObject cautCnvs;

    public GameObject CtrlCnvs { get => ctrlCnvs; }
    public GameObject GameCnvs { get => gameUICnvs; }
    public GameObject PauseCnvs { get => pauseCnvs; }
    public GameObject CautCnvs { get => cautCnvs; }

    //-------------------------------------------------------------------
    void Awake()
    {
        mainCnvsInst = Instantiate(mainCnvsPrfb);       // キャンバスのプレハブをインスタンス化

        /* オブジェクト取得 */
        ctrlCnvs  = mainCnvsInst.transform.Find("ControllerCanvas").gameObject;
        gameUICnvs= mainCnvsInst.transform.Find("GameUICanvas").gameObject;
        pauseCnvs = mainCnvsInst.transform.Find("PauseCanvas").gameObject;
        cautCnvs  = pauseCnvs.transform.Find("CautionCanvas").gameObject;

        /* 初期化 */
        pauseCnvs.SetActive(false);
    }

    //-------------------------------------------------------------------
    // ポーズ
    public void Pause()
    {
        ctrlCnvs.SetActive(false);
        gameUICnvs.SetActive(false);
        pauseCnvs.SetActive(true);
    }

    // ポーズ解除
    public void Unpause()
    {
        ctrlCnvs.SetActive(true);
        gameUICnvs.SetActive(true);
        pauseCnvs.SetActive(false);
    }

    // 警告表示
    public void Caution()
    {
        cautCnvs.SetActive(true);
    }

    // 警告解除
    public void Uncaution()
    {
        cautCnvs.SetActive(false);
    }
}
