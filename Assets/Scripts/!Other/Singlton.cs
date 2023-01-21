using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singlton<T> : MonoBehaviour where T :Component
{
    static T instance;      // �C���X�^���X�{��

    // �C���X�^���X�擾
    public static T Instance {
        get {
            if (!instance) {
                instance = (T)FindObjectOfType(typeof(T));      // �����̃C���X�^���X����

                if (!instance) {
                    SetUpInstance();
                }
            }

            return instance;
        }
    }

    // �N�����ɃV���O���g���̃Z�b�g�A�b�v
    protected virtual void Awake()
    {
        RemoveDuplicates();
    }

    // �C���X�^���X�̌����A�V�K�쐬
    static void SetUpInstance()
    {
        instance = (T)FindObjectOfType(typeof(T));      // ����

        // �V�K�쐬
        if (!instance) {
            var obj = new GameObject();         // �Q�[���I�u�W�F�N�g�쐬
            obj.name = typeof(T).Name;

            instance = obj.AddComponent<T>();   // �R���|�[�l���g�ǉ�
            DontDestroyOnLoad(obj);             // �V�[���J�ڎ��ɔj�����Ȃ�
        }
    }

    // �d���`�F�b�N�A�폜
    void RemoveDuplicates()
    {
        // �V�K�쐬
        if (!instance) {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }

        // �d�����폜
        else {
            Destroy(gameObject);
        }
    }
}
