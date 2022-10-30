using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public abstract class Buttons : MonoBehaviour {
        /* �R���|�[�l���g */
        protected SystemSound se;

        /* ���� */
        protected abstract void Awake();

        protected void SESet(GameObject obj)
		{
            GameObject audObj = obj.transform.Find("AudioManager").gameObject;
            se = audObj.GetComponent<SystemSound>();
        }
    }
}

