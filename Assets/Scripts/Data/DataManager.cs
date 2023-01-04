using System.IO;
using UnityEngine;

public class DataManager : Singleton<DataManager> {
    public SaveData data;                           // json変換するデータのクラス
    static string filepath;                         // jsonファイルのパス
    static string fileName = "Data.json";           // jsonファイル名

    //-------------------------------------------------------------------
    // 開始時にファイルチェック、読み込み
    void Awake()
    {
        // パス名取得
        GetFilePath();

        // ファイルがないとき、ファイル作成
        if (!File.Exists(filepath)) {
            Save();
        }

        // ファイルを読み込んでdataに格納
        data = Load(filepath);
    }

    // ファイルパス取得
    void GetFilePath()
	{
#if UNITY_EDITOR
        filepath = Application.dataPath + "/" + fileName;
#elif UNITY_ANDROID
        filepath = Application.persistentDataPath + "/" + fileName;
#endif
    }

    //-------------------------------------------------------------------
    // jsonとしてデータを保存
    public void Save()
    {
        string json = JsonUtility.ToJson(data);                 // jsonとして変換
        StreamWriter wr = new StreamWriter(filepath, false);    // ファイル書き込み指定

        wr.WriteLine(json);                                     // json変換した情報を書き込み
        wr.Close();                                             // ファイル閉じる
    }

    // jsonファイル読み込み
    SaveData Load(string path)
    {
        StreamReader rd = new StreamReader(path);               // ファイル読み込み指定
        string json = rd.ReadToEnd();                           // ファイル内容全て読み込む
        rd.Close();                                             // ファイル閉じる

        return JsonUtility.FromJson<SaveData>(json);            // jsonファイルを型に戻して返す
    }

	private void OnDestroy()
	{
        Save();
	}
}