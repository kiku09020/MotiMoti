using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moti {
    public abstract class HitCheckerBase : MonoBehaviour {
        protected MotiController moti;       // もち
        [SerializeField] protected string targetTagName;      // 判定調べるオブジェクトのタグ名

        private void Awake()
        {
            moti = transform.parent.GetComponent<MotiController>();
        }

        public abstract void Init();
    }
}
