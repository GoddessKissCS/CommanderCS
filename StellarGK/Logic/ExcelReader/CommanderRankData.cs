using StellarGK.Utils.ExcelReader;

namespace StellarGK.Logic.ExcelReader
{
    internal class CommanderRankData : BaseExcelReader<CommanderRankData, CommanderRankDataExcel>
    {
        public override string FileName { get { return "CommanderRankDataTable.json"; } }

        public CommanderRankDataExcel? FromRank(string CommanderRank)
        {
            var rank = int.Parse(CommanderRank.ToString());

            return All.Where(avatar => avatar.rank == rank).FirstOrDefault();
        }

    }
    public class CommanderRankDataExcel
    {
        public int rank { get; set; }
        public int medal { get; set; }
        public int gold { get; set; }
    }

}
