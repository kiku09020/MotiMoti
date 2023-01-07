using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti {
    public abstract class HitCheckerBase : MonoBehaviour {
        protected MotiController moti;       // ����
        [SerializeField] protected string targetTagName;      // ���蒲�ׂ�I�u�W�F�N�g�̃^�O��

        private void Awake()
        {
            moti = transform.parent.GetComponent<MotiController>();
        }

        public abstract void Init();
    }
}
