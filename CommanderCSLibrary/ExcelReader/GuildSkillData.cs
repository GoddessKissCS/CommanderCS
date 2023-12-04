using CommanderCS.Utils;
using Newtonsoft.Json;

namespace CommanderCS.ExcelReader
{
    public class GuildSkillData : BaseExcelReader<GuildSkillData, GuildSkillExcel>
    {
        public override string FileName
        { get { return "GuildSkillDataTable.json"; } }

        public GuildSkillExcel? FromSkillLevel(int skilllevel)
        {
            return All.Where(avatar => avatar.skilllevel == skilllevel).FirstOrDefault();
        }
    }

    public class GuildSkillExcel
    {
        [JsonProperty("index")]
        public int index { get; set; }

        [JsonProperty("idx")]
        public int idx { get; set; }

        [JsonProperty("skilllevel")]
        public int skilllevel { get; set; }

        [JsonProperty("value")]
        public int value { get; set; }

        [JsonProperty("level")]
        public int level { get; set; }

        [JsonProperty("cost")]
        public int cost { get; set; }

        [JsonProperty("name")]
        public int name { get; set; }

        [JsonProperty("description")]
        public int description { get; set; }
    }
}