using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button
{
    public class SettingsBack : Buttons
    {
        [SerializeField] GameObject settingsUI;

        public override void Clicked()
        {
            SettingsManager.Instance.SaveData();        // ê›íËÉfÅ[É^ï€ë∂
            settingsUI.SetActive(false);
        }
    }
}