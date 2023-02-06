using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEToggle : ToggleActionBase
{
    public override void Changed()
    {
        // ミュート解除
        if (toggle.IsOn) {
            SE.Instance.UnMute();
        }

        // ミュート
        else {
            SE.Instance.Mute();
        }
    }
}
