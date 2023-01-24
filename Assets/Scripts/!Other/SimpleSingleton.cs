using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSingleton<T> : MonoBehaviour where T : Component
{
    static T instance;

    public static T Instance {
		get{
			if (!instance) {
                instance = (T)FindObjectOfType(typeof(T));      // ���ɍ쐬���ꂽ�C���X�^���X��T��
			}

            return instance;
		}
	}

//-------------------------------------------------------------------

}
