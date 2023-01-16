using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    static T instance;

    public static T Instance {
		get{
			if (!instance) {
                instance = (T)FindObjectOfType(typeof(T));      // ���ɍ쐬���ꂽ�C���X�^���X��T��

				if (!instance) {        // �C���X�^���X��������΁A�V�����쐬
                    SetUpInstance();
				}
			}

            return instance;
		}
	}

//-------------------------------------------------------------------
    // �C���X�^���X�̍쐬
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
