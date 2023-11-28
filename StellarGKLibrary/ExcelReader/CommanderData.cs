using Newtonsoft.Json;
using CommanderCS.Utils;

namespace CommanderCS.ExcelReader
{
    public class CommanderData : BaseExcelReader<CommanderData, CommanderDataExcel>
    {
        public override string FileName
        { get { return "CommanderDataTable.json"; } }

        public CommanderDataExcel? FromId(int idx)
        {
            return All.Where(avatar => avatar.id == idx).FirstOrDefault();
        }

        public CommanderDataExcel? FromId(string idx)
        {
            return All.Where(avatar => avatar.id == int.Parse(idx)).FirstOrDefault();
        }
    }

    public class CommanderDataExcel
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("S_Idx")]
        public int S_Idx { get; set; }

        [JsonProperty("C_Type")]
        public int C_Type { get; set; }

        [JsonProperty("unitId")]
        public int unitId { get; set; }

        [JsonProperty("resourceId")]
        public string resourceId { get; set; }

        [JsonProperty("_isAcademyExposure")]
        public string _isAcademyExposure { get; set; }

        [JsonProperty("academyExposureRate")]
        public int academyExposureRate { get; set; }

        [JsonProperty("grade")]
        public int grade { get; set; }

        [JsonProperty("recruitHonor")]
        public int recruitHonor { get; set; }

        [JsonProperty("recruitGold")]
        public int recruitGold { get; set; }

        [JsonProperty("overlapReward")]
        public int overlapReward { get; set; }

        [JsonProperty("medalExplanation")]
        public int medalExplanation { get; set; }

        [JsonProperty("favormax")]
        public int favormax { get; set; }

        [JsonProperty("explanation")]
        public int explanation { get; set; }

        [JsonProperty("marry")]
        public int marry { get; set; }

        [JsonProperty("dormitory")]
        public int dormitory { get; set; }

        [JsonProperty("vip")]
        public int vip { get; set; }
    }
}