using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class SettingsButton :Buttons
    {
        [SerializeField] GameObject settingsUI;

        public override void Clicked()
        {
            settingsUI.SetActive(true);
        }
    }
}