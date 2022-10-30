using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class Exit : PauseButtons {
        public override void Clicked()
        {
            se.Play((int)SystemSound.AudioName.click);
            pause.isExit = true;
            pause.SetCaution();
            canvas.ActivateCautionUI();
        }
    }
}