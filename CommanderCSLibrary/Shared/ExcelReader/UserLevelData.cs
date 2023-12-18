using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.ExcelReader
{
    public class UserLevelData : BaseExcelReader<UserLevelData, UserLevelDataExcel>
    {
        public override string FileName
        { get { return "UserLevelDataTable.json"; } }

        public UserLevelDataExcel? FromLevel(int level)
        {
            return All.Where(avatar => avatar.level == level).FirstOrDefault();
        }

        public UserLevelDataExcel? FromLevel(string level)
        {
            return All.Where(avatar => avatar.level == int.Parse(level)).FirstOrDefault();
        }
    }

    public class UserLevelDataExcel
    {
        [JsonProperty("level")]
        public int level { get; set; }

        [JsonProperty("exp")]
        public int exp { get; set; }

        [JsonProperty("uExp")]
        public int uExp { get; set; }

        [JsonProperty("maxBullet")]
        public int maxBullet { get; set; }

        [JsonProperty("maxSkill")]
        public int maxSkill { get; set; }

        [JsonProperty("rewardBullet")]
        public int rewardBullet { get; set; }

        [JsonProperty("bankGold")]
        public int bankGold { get; set; }

        [JsonProperty("goldIncrease")]
        public double goldIncrease { get; set; }
    }
}