using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Button {
    public abstract class ButtonAbstract : MonoBehaviour {

        /* プロパティ */

        /* コンポーネント */
        protected SystemSound se;

        /* 抽象メソッド */
        public abstract void Clicked();

        /* 処理 */
        protected virtual void Awake()
        {
            GameObject gmObj = GameObject.Find("GameManager");
            GameObject audObj = gmObj.transform.Find("AudioManager").gameObject;

            se = audObj.GetComponent<SystemSound>();
        }
    }
}

