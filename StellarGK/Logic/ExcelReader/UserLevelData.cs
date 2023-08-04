using System.Text.Json.Serialization;
using StellarGK.Utils.ExcelReader;

namespace StellarGK.Logic.ExcelReader
{
    internal class UserLevelData : BaseExcelReader<UserLevelData, UserLevelDataExcel>
    {
        public override string FileName { get { return "UserLevelDataTable.json"; } }

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
        [JsonPropertyName("level")]
        public int level { get; set; }
        [JsonPropertyName("exp")]
        public int exp { get; set; }
        [JsonPropertyName("uExp")]
        public int uExp { get; set; }
        [JsonPropertyName("maxBullet")]
        public int maxBullet { get; set; }
        [JsonPropertyName("maxSkill")]
        public int maxSkill { get; set; }
        [JsonPropertyName("rewardBullet")]
        public int rewardBullet { get; set; }
        [JsonPropertyName("bankGold")]
        public int bankGold { get; set; }
        [JsonPropertyName("goldIncrease")]
        public int goldIncrease { get; set; }
    }

}
