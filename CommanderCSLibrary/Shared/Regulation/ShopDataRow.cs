using CommanderCSLibrary.Shared.Enum;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation
{
    [Serializable]
    [JsonObject]
    public class ShopDataRow : DataRow
    {
        public string id { get; private set; }

        public EShopType type { get; private set; }

        public int grade { get; private set; }

        public string g_idx { get; private set; }

        public int startRechargePrice { get; private set; }

        public int numberMeasure { get; private set; }

        public string priceAddPercent { get; private set; }

        public List<string> openTime { get; private set; }

        private ShopDataRow()
        {
        }

        public string GetKey()
        {
            return id;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }

}