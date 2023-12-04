using CommanderCS.Utils;
using Newtonsoft.Json;

namespace CommanderCS.ExcelReader
{
    public class CommanderRankData : BaseExcelReader<CommanderRankData, CommanderRankDataExcel>
    {
        public override string FileName
        { get { return "CommanderRankDataTable.json"; } }

        public CommanderRankDataExcel? FromRank(string CommanderRank)
        {
            var rank = int.Parse(CommanderRank.ToString());

            return All.Where(avatar => avatar.rank == rank).FirstOrDefault();
        }
    }

    public class CommanderRankDataExcel
    {
        [JsonProperty("rank")]
        public int rank { get; set; }

        [JsonProperty("medal")]
        public int medal { get; set; }

        [JsonProperty("gold")]
        public int gold { get; set; }
    }
}