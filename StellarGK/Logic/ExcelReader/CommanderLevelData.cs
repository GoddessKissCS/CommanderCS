using StellarGK.Tools;

namespace StellarGK.Logic.ExcelReader
{
    public class CommanderLevelData : BaseExcelReader<CommanderLevelData, CommanderLevelDataExcel>
    {
        public override string FileName { get { return "CommanderLevelDataTable.json"; } }

        public CommanderLevelDataExcel? FromLevel(int idx)
        {
            return All.Where(avatar => avatar.level == idx).FirstOrDefault();
        }

    }

    public class CommanderLevelDataExcel
    {
        public int level { get; set; }
        public int exp { get; set; }
        public int aexp { get; set; }
    }
}
