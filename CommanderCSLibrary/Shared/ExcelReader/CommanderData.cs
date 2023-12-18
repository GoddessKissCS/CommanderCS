using CommanderCSLibrary.Shared;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.ExcelReader
{
    public class CommanderData : BaseExcelReader<CommanderData, CommanderDataExcel>
    {
        public override string FileName { get { return "CommanderDataTable.json"; } }

        public CommanderDataExcel? FromId(string idx)
        {
            return All.Where(avatar => avatar.id == idx).FirstOrDefault();
        }
    }

    public class CommanderDataExcel
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("S_Idx")]
        public string S_Idx { get; set; }

        [JsonProperty("C_Type")]
        public int C_Type { get; set; }

        [JsonProperty("npc")]
        public bool npc { get; set; }

        [JsonProperty("resourceId")]
        public string resourceId { get; set; }

        [JsonProperty("thumbnailId")]
        public string thumbnailId { get; set; }

        [JsonProperty("worldMapRewardId")]
        public string worldMapRewardId { get; set; }

        [JsonProperty("gender")]
        public int gender { get; set; }

        [JsonProperty("unitId")]
        public string unitId { get; set; }

        [JsonProperty("isAcademyExposure")]
        public bool isAcademyExposure { get; set; }

        [JsonProperty("grade")]
        public int grade { get; set; }

        [JsonProperty("recruitHonor")]
        public int recruitHonor { get; set; }

        [JsonProperty("recruitGold")]
        public int recruitGold { get; set; }

        [JsonProperty("overlapReward")]
        public int overlapReward { get; set; }

        [JsonProperty("leadership")]
        public int leadership { get; set; }

        [JsonProperty("favormax")]
        public int favormax { get; set; }

        [JsonProperty("medalExplanation")]
        public string medalExplanation { get; set; }

        [JsonProperty("explanation")]
        public string explanation { get; set; }

        [JsonProperty("marry")]
        public int marry { get; set; }

        [JsonProperty("vip")]
        public int vip { get; set; }

        [JsonProperty("levelPattern")]
        public object levelPattern { get; set; }

        [JsonProperty("nickname")]
        public string nickname { get; set; }
    }
}