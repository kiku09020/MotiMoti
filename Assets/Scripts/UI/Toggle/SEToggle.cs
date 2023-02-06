using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEToggle : ToggleActionBase
{
    public override void Changed()
    {
        // �~���[�g����
        if (toggle.IsOn) {
            SE.Instance.UnMute();
        }

        // �~���[�g
        else {
            SE.Instance.Mute();
        }
    }
}
