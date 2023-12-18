using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Regulation;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Ro
{
    [JsonObject]
    public class RoItem
    {
        public string id;

        public string nameIdx;

        public int level;

        public EItemSetType setType;

        public int pointType;

        public EItemStatType statType;

        public EItemStatType upgradeType;

        public EItemStatType disassembleType;

        public bool isEquip;

        public int statPoint;

        public string currEquipCommanderId;

        public int itemCount;

        public static RoItem Create(string id, int lv, int itemCnt, string commanderId)
        {
            EquipItemDataRow equipItemDataRow = Constants.regulation.equipItemDtbl.Find((EquipItemDataRow row) => row.key == id);
            RoItem roItem = new()
            {
                id = id,
                level = lv,
                nameIdx = equipItemDataRow.equipItemName,
                setType = equipItemDataRow.setItemType,
                pointType = equipItemDataRow.pointType,
                statType = equipItemDataRow.statType,
                upgradeType = equipItemDataRow.UpgradeType,
                disassembleType = equipItemDataRow.disassembleType
            };
            roItem.statPoint = equipItemDataRow.statBasePoint + (roItem.level - 1) * equipItemDataRow.statAddPoint;
            roItem.currEquipCommanderId = commanderId;
            roItem.itemCount = itemCnt;
            if (!string.IsNullOrEmpty(commanderId))
            {
                roItem.isEquip = true;
            }
            else
            {
                roItem.isEquip = false;
            }
            return roItem;
        }

        public void SetItemLevel(string id, int curLevel)
        {
            EquipItemDataRow equipItemDataRow = Constants.regulation.equipItemDtbl.Find((EquipItemDataRow row) => row.key == id);
            if (equipItemDataRow != null)
            {
                level = curLevel;
                statPoint = equipItemDataRow.statBasePoint + (curLevel - 1) * equipItemDataRow.statAddPoint;
            }
        }
    }
}