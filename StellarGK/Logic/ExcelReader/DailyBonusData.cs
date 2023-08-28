using StellarGK.Tools;

namespace StellarGK.Logic.ExcelReader
{
    public class DailyBonusData : BaseExcelReader<DailyBonusData, DailyBonusDataExcel>
    {
        public override string FileName { get { return "DailyBonusDataTable.json"; } }

        public DailyBonusDataExcel? FromDay(int day, string startTime)
        {
            return All.Where(avatar => avatar.day == day).FirstOrDefault();
        }

    }

    public class DailyBonusDataExcel
    {
        public int index { get; set; }
        public int version { get; set; }
        public int day { get; set; }
        public int rewardType { get; set; }
        public int goodsId { get; set; }
        public int goodsCount { get; set; }
        public int startTime { get; set; }
        public int endTime { get; set; }
        public int vipLevel { get; set; }
        public int multiply { get; set; }
    }
}
