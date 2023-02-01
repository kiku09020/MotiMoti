using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMToggle : ToggleActionBase
{
    public override void Changed()
    {
        // ミュート解除
        if (toggle.IsOn) {
            BGM.Instance.UnMute();
        }

        // ミュート
        else {
            BGM.Instance.Mute();
        }
    }
}
