using Newtonsoft.Json;
using CommanderCS.Utils;

namespace CommanderCS.ExcelReader
{
    public class GoodsData : BaseExcelReader<GoodsData, GoodsDataExcel>
    {
        public override string FileName
        { get { return "GoodsDataTable.json"; } }

        public GoodsDataExcel? FromServerFieldName(string name)
        {
            return All.Where(avatar => avatar.serverFieldName == name).FirstOrDefault();
        }

        public Dictionary<string, int> GetAllGoods(int count)
        {
            Dictionary<string, int> allGoods = new();

            string path = File.ReadAllText($"Resources\\ExcelOutputAsset\\{FileName}");

            List<GoodsDataExcel> items = JsonConvert.DeserializeObject<List<GoodsDataExcel>>(path);

            foreach (var item in items)
            {
                allGoods.Add(item.type.ToString(), count);
            }

            return allGoods;
        }
    }

    public class GoodsDataExcel
    {
        [JsonProperty("type")]
        public int type { get; set; }

        [JsonProperty("name")]
        public int name { get; set; }

        [JsonProperty("serverFieldName")]
        public string serverFieldName { get; set; }

        [JsonProperty("max")]
        public int max { get; set; }

        [JsonProperty("rechargeType")]
        public int rechargeType { get; set; }

        [JsonProperty("rechargeTime")]
        public int rechargeTime { get; set; }

        [JsonProperty("rechargeMax")]
        public int rechargeMax { get; set; }

        [JsonProperty("description")]
        public int description { get; set; }

        [JsonProperty("storage")]
        public int storage { get; set; }

        [JsonProperty("icon")]
        public string icon { get; set; }

        [JsonProperty("openType")]
        public int openType { get; set; }
    }
}