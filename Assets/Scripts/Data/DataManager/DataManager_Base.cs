using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Data {
    public abstract class DataManager_Base<T> : SimpleSingleton<T> where T : DataManager_Base<T> {
        protected string FilePath { get; private set; }     // ファイルパス
        protected abstract string FileName { get; }         // ファイル名

        //-------------------------------------------------------------------
        // ファイルパス取得
        void GetFilePath()
        {
            var fileNameWithExt = $"{FileName}.json";       // 拡張子付きファイル名

#if UNITY_EDITOR        // Editor
            FilePath = $"{Application.dataPath}/{fileNameWithExt}";

#else                   // Platform
            FilePath = $"{Application.persistentDataPath}/{fileNameWithExt}";
#endif
        }

        /// <summary>
        /// データのセットアップ
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
        /// jsonとしてデータ保存
        /// </summary>
        protected void Save(IData data)
        {
            var json = JsonUtility.ToJson(data);            // Dataをjsonとして変換
            var wr = new StreamWriter(FilePath, false);     // ファイル書き込み設定の指定

            wr.WriteLine(json);                             // jsonとして変換した情報をファイルに書き込む
            wr.Close();                                     // ファイルを閉じる
        }

        /// <summary>
        /// json読み込み
        /// </summary>
        protected Data Load<Data>() where Data : IData
        {
            var rd = new StreamReader(FilePath);            // ファイル読み込み設定の指定
            var json = rd.ReadToEnd();                      // ファイル内容を全て読み込む
            rd.Close();                                     // ファイルを閉じる

            return JsonUtility.FromJson<Data>(json);        // jsonファイルをData型に戻して返す
        }
    }
}