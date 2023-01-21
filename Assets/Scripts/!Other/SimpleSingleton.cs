using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSingleton<T> : MonoBehaviour where T : Component
{
    static T instance;

    public static T Instance {
		get{
			if (!instance) {
                instance = (T)FindObjectOfType(typeof(T));      // 既に作成されたインスタンスを探す
			}

            return instance;
		}
	}

//-------------------------------------------------------------------

}
