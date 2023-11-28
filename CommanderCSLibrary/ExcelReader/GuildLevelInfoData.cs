using Newtonsoft.Json;
using CommanderCS.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanderCS.ExcelReader
{
    public class GuildLevelInfoData : BaseExcelReader<GuildLevelInfoData, GuildLevelInfoExcel>
    {
        public override string FileName { get { return "GuildLevelInfoDataTable.json"; } }
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
