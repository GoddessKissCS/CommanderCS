

namespace CommanderCSLibrary.Shared.ExcelReader
{
    public class UnitDataTable : BaseExcelReader<UnitDataTable, UnitDataExcel>
    {
        public override string FileName { get { return "UnitDataTable.json"; } }

    }

    public class UnitDataExcel
    {
        public List<string> skillDrks { get; set; }
        public string key { get; set; }
        public string nameKey { get; set; }
        public string prefabId { get; set; }
        public string resourceName { get; set; }
        public string unitSmallIconName { get; set; }
        public int maxHealth { get; set; }
        public int speed { get; set; }
        public int branch { get; set; }
        public int type { get; set; }
        public int typeUpper { get; set; }
        public int typeDown { get; set; }
        public int typeBonus { get; set; }
        public int typeHandicap { get; set; }
        public bool isCommander { get; set; }
        public int gold { get; set; }
        public int leadership { get; set; }
        public int attackDamage { get; set; }
        public int defense { get; set; }
        public int accuracy { get; set; }
        public int criticalChance { get; set; }
        public int criticalDamageBonus { get; set; }
        public int unlockLevel { get; set; }
        public int luck { get; set; }
        public bool isHidden { get; set; }
        public string dropGoldPattern { get; set; }
        public string levelPattern { get; set; }
        public string classPattern { get; set; }
        public string afterLevelPattern { get; set; }
        public string afterClassPattern { get; set; }
        public int job { get; set; }
        public int stateAllImmunity { get; set; }
        public string explanation { get; set; }
        public int originAttackDamage { get; set; }
        public int originDefense { get; set; }
        public int originAccuracy { get; set; }
        public int originCriticalChance { get; set; }
        public int originCriticalDamageBonus { get; set; }
        public int originSpeed { get; set; }
        public int originLuck { get; set; }
        public int originMaxHealth { get; set; }
        public int partHead { get; set; }
        public int partRightHand { get; set; }
        public int partLeftHand { get; set; }
        public int partBody { get; set; }
        public int partSpecial { get; set; }
    }

}
