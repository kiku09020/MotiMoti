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
        void Awake()
        {
            GameObject seListObj = transform.Find("ButtonSEList").gameObject;

            se = seListObj.GetComponent<SystemSound>();
        }
    }
}

