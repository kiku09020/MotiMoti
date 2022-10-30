using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public abstract class Buttons : MonoBehaviour {
        /* コンポーネント */
        protected SystemSound se;

        /* 処理 */
        protected abstract void Awake();

        protected void SESet(GameObject obj)
		{
            GameObject audObj = obj.transform.Find("AudioManager").gameObject;
            se = audObj.GetComponent<SystemSound>();
        }
    }
}

