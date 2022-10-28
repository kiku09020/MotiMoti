using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public class StartBtn : ButtonAbstract {
        SceneController scene;

        private void Start()
        {
            GameObject titleObj = GameObject.Find("TitleManager");
            scene = titleObj.GetComponent<SceneController>();
        }

        public override void Clicked()
        {
            se.Play((int)SystemSound.AudioName.decision);
            scene.LoadNextScene();
        }
    }
}
