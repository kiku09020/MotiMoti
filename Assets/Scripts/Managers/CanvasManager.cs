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
    public void Pause(bool pause)
    {
        // ポーズ時
        if (pause) {
            ctrlCnvs.SetActive(false);
            gameUICnvs.SetActive(false);
            pauseCnvs.SetActive(true);
        }

        // ポーズ終了時
        else {
            ctrlCnvs.SetActive(true);
            gameUICnvs.SetActive(true);
            pauseCnvs.SetActive(false);
        }
    }

    // 警告表示
    public void Caution(bool caution)
    {
        // 警告時
        if (caution) {
            cautCnvs.SetActive(true);
        }

        // 警告解除時
        else {
            cautCnvs.SetActive(false);
        }
    }
}
