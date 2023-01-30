using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button{
    public class GithubButton : Buttons
    {
        public override void Clicked()
        {
            Application.OpenURL("https://github.com/kiku09020/MotiMoti");
        }
    }
}