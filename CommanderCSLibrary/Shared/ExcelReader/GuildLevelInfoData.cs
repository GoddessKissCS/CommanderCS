using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.ExcelReader
{
    public class GuildLevelInfoData : BaseExcelReader<GuildLevelInfoData, GuildLevelInfoExcel>
    {
        public override string FileName
        { get { return "GuildLevelInfoDataTable.json"; } }

        public GuildLevelInfoExcel? FromLevel(int level)
        {
            return All.Where(avatar => avatar.level == level).FirstOrDefault();
        }
    }

    public class GuildLevelInfoExcel
    {
        [JsonProperty("level")]
        public int level { get; set; }

        [JsonProperty("maxcount")]
        public int maxcount { get; set; }

        [JsonProperty("cost")]
        public int cost { get; set; }
    }
}