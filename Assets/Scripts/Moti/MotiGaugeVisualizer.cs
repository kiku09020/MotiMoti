using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MotiGaugeVisualizer : Singleton<MotiGaugeVisualizer>
{
    [Header("Easing")]
    [SerializeField] float easeTime;        // イージング時間
    [SerializeField] Ease easeType;         // イージングタイプ

    [Header("UI")]
    [SerializeField] Image powerImage;      // ゲージ画像
    [SerializeField] Text comboText;        // コンボテキスト

    static float dispPower;         // 表示
    static float targetPower;       // 目標

//-------------------------------------------------------------------
    void Awake()
    {
        MotiGaugeManager.Init();

        dispPower = 0;
        targetPower = 0;
    }

    void FixedUpdate()
    {
        MotiGaugeManager.MotiGaugeUpdate();
        DispPower();
        DispCombo();
    }

//-------------------------------------------------------------------
    // 表示パワーのセット(パワー加算時に呼び出し)
    public void SetDispPower()
	{
        SetTargetPower();

        DOVirtual.Float(dispPower, targetPower, easeTime, value=>{
            dispPower = value;
        }).SetEase(easeType);

	}

    // 目標パワーのセット
    void SetTargetPower()
	{
        targetPower = MotiGaugeManager.NowPower / 100f;
	}

    // 表示コンボセット(コンボ加算時)
    public void DispCombo()
    {
        if (MotiGaugeManager.ComboCount > 1) {
            comboText.text = $"×{MotiGaugeManager.ComboCount}";
        }
        else {
            comboText.text = "";
        }
    }

    // パワーの表示
    void DispPower()
	{
        powerImage.fillAmount = dispPower;
	}
}
