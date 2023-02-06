using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMToggle : ToggleActionBase
{
    public override void Changed()
    {
        // �~���[�g����
        if (toggle.IsOn) {
            BGM.Instance.UnMute();
        }

        // �~���[�g
        else {
            BGM.Instance.Mute();
        }
    }
}
