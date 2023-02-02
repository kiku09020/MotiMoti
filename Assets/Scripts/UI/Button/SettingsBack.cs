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
            SE.Instance.Play("btn_cancel");

            SettingsManager.Instance.SaveData();        // �ݒ�f�[�^�ۑ�
            settingsUI.SetActive(false);
        }
    }
}