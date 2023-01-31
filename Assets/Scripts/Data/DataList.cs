namespace Data {
    // �f�[�^�C���^�[�t�F�[�X
    public interface IData { }

    // �Z�[�u�f�[�^
    [System.Serializable]
    public class SaveData : IData {
        public int highScore;
    }

    // �ݒ�p�����[�^
    [System.Serializable]
    public class SettingsData :IData{
        public bool enableBGM;
        public bool enableSE;
        public int sensitivity;
    }
}