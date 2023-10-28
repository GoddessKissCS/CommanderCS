using StellarGKLibrary.Utils;

namespace StellarGKLibrary.ExcelReader
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
        public int level { get; set; }
        public int exp { get; set; }
        public int uExp { get; set; }
        public int maxBullet { get; set; }
        public int maxSkill { get; set; }
        public int rewardBullet { get; set; }
        public int bankGold { get; set; }
        public int goldIncrease { get; set; }
    }
}