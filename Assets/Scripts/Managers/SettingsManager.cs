using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Data;

public class SettingsManager : SimpleSingleton<SettingsManager>
{
    [Header("Toggle")]
    [SerializeField] SmartToggle bgmToggle;
    [SerializeField] SmartToggle seToggle;

    [Header("Slider")]
    [SerializeField] Slider sensitivitySlider;

    private void OnEnable()
    {
        SetValues();
    }

    // データ→パラメータ
    void SetValues()
    {
        var data = SettingsDataManager.Instance.dataInfo;

        bgmToggle.Value = data.enableBGM;
        seToggle.Value = data.enableSE;
        sensitivitySlider.value = data.sensitivity;
    }

    // パラメータ→データ
    public void SaveData()
    {
        var data = SettingsDataManager.Instance.dataInfo;

        data.enableBGM = bgmToggle.Value;
        data.enableSE = seToggle.Value;
        data.sensitivity = (int)sensitivitySlider.value;

        SettingsDataManager.Instance.dataInfo = data;
    }
}
