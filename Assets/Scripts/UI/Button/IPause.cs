using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public interface IPause  {
        /* プロパティ */

        /* メソッド */
        IEnumerator WaitCanvasActivate();
    }
}