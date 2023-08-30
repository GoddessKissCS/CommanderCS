using Newtonsoft.Json;
using StellarGKLibrary.Utils;

namespace StellarGKLibrary.ExcelReader
{
    public class GoodsData : BaseExcelReader<GoodsData, GoodsDataExcel>
    {
        public override string FileName { get { return "GoodsDataTable.json"; } }


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
        public int type { get; set; }
        public int name { get; set; }
        public string serverFieldName { get; set; }
        public int max { get; set; }
        public int rechargeType { get; set; }
        public int rechargeTime { get; set; }
        public int rechargeMax { get; set; }
        public int description { get; set; }
        public int storage { get; set; }
        public string icon { get; set; }
        public int openType { get; set; }
    }
}
