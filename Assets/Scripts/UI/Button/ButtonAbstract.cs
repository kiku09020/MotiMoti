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
        void Awake()
        {
            GameObject seListObj = transform.Find("ButtonSEList").gameObject;

            se = seListObj.GetComponent<SystemSound>();
        }
    }
}

