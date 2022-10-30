using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class Retry : PauseButtons {

        public override void Clicked()
        {
            se.Play((int)SystemSound.AudioName.click);
            pause.isRetry = true;
            pause.SetCaution();
            canvas.ActivateCautionUI();
        }
    }
}