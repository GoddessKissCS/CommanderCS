using StellarGKLibrary.Utils;

namespace StellarGKLibrary.ExcelReader
{
    public class CommanderData : BaseExcelReader<CommanderData, CommanderDataExcel>
    {
        public override string FileName { get { return "CommanderDataTable.json"; } }

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
        public int id { get; set; }
        public int S_Idx { get; set; }
        public int C_Type { get; set; }
        public int unitId { get; set; }
        public string resourceId { get; set; }
        public string _isAcademyExposure { get; set; }
        public int academyExposureRate { get; set; }
        public int grade { get; set; }
        public int recruitHonor { get; set; }
        public int recruitGold { get; set; }
        public int overlapReward { get; set; }
        public int medalExplanation { get; set; }
        public int favormax { get; set; }
        public int explanation { get; set; }
        public int marry { get; set; }
        public int dormitory { get; set; }
        public int vip { get; set; }
    }
}
