using CommanderCSLibrary.Shared;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.ExcelReader
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

        [JsonProperty("medalGoodsType")]
        public int medalGoodsType { get; set; }

        [JsonProperty("medal")]
        public int medal { get; set; }

        [JsonProperty("gold")]
        public int gold { get; set; }

        [JsonProperty("completeCash")]
        public int completeCash { get; set; }

        [JsonProperty("time")]
        public int time { get; set; }
    }
}