using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    static T instance;

    public static T Instance {
		get{
			if (!instance) {
                instance = (T)FindObjectOfType(typeof(T));      // 既に作成されたインスタンスを探す

				if (!instance) {        // インスタンスが無ければ、新しく作成
                    SetUpInstance();
				}
			}

            return instance;
		}
	}

//-------------------------------------------------------------------
    // インスタンスの作成
    static void SetUpInstance()
	{
        instance = (T)FindObjectOfType(typeof(T));

		if (!instance) {
            var obj = new GameObject();
            obj.name = typeof(T).Name;

            instance = obj.AddComponent<T>();
            DontDestroyOnLoad(obj);
		}
	}
}
