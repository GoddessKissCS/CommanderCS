using CommanderCS.Library.Enums;
using CommanderCS.Library.Regulation;
using Newtonsoft.Json;

namespace CommanderCS.Library.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class EquipItemDataRow : DataRow
    {
        public string key { get; private set; }

        public int pointType { get; private set; }

        public EItemSetType setItemType { get; private set; }

        public int statEffect { get; private set; }

        public EItemStatType statType { get; private set; }

        public int statBasePoint { get; private set; }

        public int statAddPoint { get; private set; }

        public EItemStatType UpgradeType { get; private set; }

        public EItemStatType disassembleType { get; private set; }

        public string equipItemIcon { get; private set; }

        public string equipItemName { get; private set; }

        public string equipItemSubText { get; set; }

        public string GetKey()
        {
            return key;
        }

        public int GetStatPoint(int level)
        {
            return statBasePoint + (level - 1) * statAddPoint;
        }
    }
}