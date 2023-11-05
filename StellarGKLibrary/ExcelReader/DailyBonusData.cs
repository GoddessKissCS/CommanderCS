using Newtonsoft.Json;
using StellarGKLibrary.Utils;

namespace StellarGKLibrary.ExcelReader
{
    public class DailyBonusData : BaseExcelReader<DailyBonusData, DailyBonusDataExcel>
    {
        public override string FileName
        { get { return "DailyBonusDataTable.json"; } }

        public DailyBonusDataExcel? FromDay(int day, int startTime)
        {
            return All.Where(avatar => avatar.day == day)
                      .Where(avatar => avatar.startTime == startTime)
                      .FirstOrDefault();
        }
    }

    public class DailyBonusDataExcel
    {
        [JsonProperty("index")]
        public int index { get; set; }

        [JsonProperty("version")]
        public int version { get; set; }

        [JsonProperty("day")]
        public int day { get; set; }

        [JsonProperty("rewardType")]
        public int rewardType { get; set; }

        [JsonProperty("goodsId")]
        public int goodsId { get; set; }

        [JsonProperty("goodsCount")]
        public int goodsCount { get; set; }

        [JsonProperty("startTime")]
        public int startTime { get; set; }

        [JsonProperty("endTime")]
        public int endTime { get; set; }

        [JsonProperty("vipLevel")]
        public int vipLevel { get; set; }

        [JsonProperty("multiply")]
        public int multiply { get; set; }
    }
}