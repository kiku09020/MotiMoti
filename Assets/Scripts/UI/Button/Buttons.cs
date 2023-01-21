using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public abstract class Buttons : MonoBehaviour {
        /* èàóù */
        protected abstract void Awake();

        protected void SESet(GameObject obj)
		{
            GameObject audObj = obj.transform.Find("AudioManager").gameObject;
        }
    }
}

