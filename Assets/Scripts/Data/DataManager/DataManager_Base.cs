using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Data {
    public abstract class DataManager_Base<T> : SimpleSingleton<T> where T : DataManager_Base<T> {
        protected string FilePath { get; private set; }     // �t�@�C���p�X
        protected abstract string FileName { get; }         // �t�@�C����

        //-------------------------------------------------------------------
        // �t�@�C���p�X�擾
        void GetFilePath()
        {
            var fileNameWithExt = $"{FileName}.json";       // �g���q�t���t�@�C����

#if UNITY_EDITOR        // Editor
            FilePath = $"{Application.dataPath}/{fileNameWithExt}";

#else                   // Platform
            FilePath = $"{Application.persistentDataPath}/{fileNameWithExt}";
#endif
        }

        /// <summary>
        /// �f�[�^�̃Z�b�g�A�b�v
        /// </summary>
        protected Data SetUp<Data>(IData data) where Data : IData
        {
            GetFilePath();

            if (!File.Exists(FilePath)) {
                Save(data);
            }

            return Load<Data>();
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// json�Ƃ��ăf�[�^�ۑ�
        /// </summary>
        protected void Save(IData data)
        {
            var json = JsonUtility.ToJson(data);            // Data��json�Ƃ��ĕϊ�
            var wr = new StreamWriter(FilePath, false);     // �t�@�C���������ݐݒ�̎w��

            wr.WriteLine(json);                             // json�Ƃ��ĕϊ����������t�@�C���ɏ�������
            wr.Close();                                     // �t�@�C�������
        }

        /// <summary>
        /// json�ǂݍ���
        /// </summary>
        protected Data Load<Data>() where Data : IData
        {
            var rd = new StreamReader(FilePath);            // �t�@�C���ǂݍ��ݐݒ�̎w��
            var json = rd.ReadToEnd();                      // �t�@�C�����e��S�ēǂݍ���
            rd.Close();                                     // �t�@�C�������

            return JsonUtility.FromJson<Data>(json);        // json�t�@�C����Data�^�ɖ߂��ĕԂ�
        }
    }
}