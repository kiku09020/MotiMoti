using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public abstract class ButtonAbstract : MonoBehaviour {

        /* �v���p�e�B */

        /* �R���|�[�l���g */
        protected SystemSound se;

        /* ���ۃ��\�b�h */
        public abstract void Clicked();

        /* ���� */
        protected virtual void Awake()
        {
            GameObject gmObj = GameObject.Find("GameManager");
            GameObject audObj = gmObj.transform.Find("AudioManager").gameObject;

            se = audObj.GetComponent<SystemSound>();
        }
    }
}

