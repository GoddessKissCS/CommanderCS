using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.ExcelReader
{
    public class SweepData : BaseExcelReader<SweepData, SweepDataExcel>
    {
        public override string FileName
        { get { return "SweepDataTable.json"; } }
    }

    public class SweepDataExcel
    {
        [JsonProperty("index")]
        public int index { get; set; }

        [JsonProperty("type")]
        public int type { get; set; }

        [JsonProperty("level")]
        public int level { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("minLevel")]
        public int minLevel { get; set; }

        [JsonProperty("gid")]
        public int gid { get; set; }

        [JsonProperty("useValue")]
        public int useValue { get; set; }

        [JsonProperty("battleType")]
        public int battleType { get; set; }

        [JsonProperty("helper")]
        public string helper { get; set; }

        [JsonProperty("uid")]
        public string uid { get; set; }

        [JsonProperty("battlemap")]
        public string battlemap { get; set; }

        [JsonProperty("enemymap")]
        public string enemymap { get; set; }

        [JsonProperty("bgm")]
        public string bgm { get; set; }

        [JsonProperty("endTurn")]
        public int endTurn { get; set; }
    }
}