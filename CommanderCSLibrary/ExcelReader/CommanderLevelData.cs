using Newtonsoft.Json;
using CommanderCS.Utils;

namespace CommanderCS.ExcelReader
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
        [JsonProperty("level")]
        public int level { get; set; }

        [JsonProperty("exp")]
        public int exp { get; set; }

        [JsonProperty("aexp")]
        public int aexp { get; set; }
    }
}