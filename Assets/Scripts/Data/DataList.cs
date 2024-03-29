namespace Data {
    // データインターフェース
    public interface IData { }

    // セーブデータ
    [System.Serializable]
    public class SaveData : IData {
        public int highScore;
    }

    // 設定パラメータ
    [System.Serializable]
    public class SettingsData :IData{
        public bool enableBGM = true;
        public bool enableSE = true;
        public int sensitivity = 3;
    }
}