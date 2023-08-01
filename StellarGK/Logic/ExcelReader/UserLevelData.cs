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
        public int level;
        public int exp;
        public int uExp;
        public int maxBullet;
        public int maxSkill;
        public int rewardBullet;
        public int bankGold;
        public int goldIncrease;
    }

}
