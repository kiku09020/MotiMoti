using UnityEngine;

namespace Data {
    public class SaveDataManager : DataManager_Base<SaveDataManager> {
        protected override string FileName => "SaveData";

        // 外部参照用のデータ情報
        public SaveData datainfo; 

        void Awake()
        {
            datainfo = SetUp<SaveData>(datainfo);
        }

        // 破棄される際に保存
        private void OnDestroy()
        {
            Save(datainfo);
        }
    }
}