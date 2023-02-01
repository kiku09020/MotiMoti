using UnityEngine;

namespace Data {
    public class SettingsDataManager : DataManager_Base<SettingsDataManager> {
        protected override string FileName => "SettingsData";

        public SettingsData dataInfo;

        private void OnEnable()
        {
            dataInfo = SetUp<SettingsData>(dataInfo);
        }

        private void OnDestroy()
        {
            Save(dataInfo);
        }
    }
}