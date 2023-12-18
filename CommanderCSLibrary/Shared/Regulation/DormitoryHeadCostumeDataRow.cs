using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation
{
    [Serializable]
    [JsonObject]
    public class DormitoryHeadCostumeDataRow : DataRow
    {
        private GoodsDataRow _goodsDr;

        [JsonProperty("ctid")]
        public string id { get; private set; }

        public string cid { get; private set; }

        public string name { get; private set; }

        [JsonProperty("desc")]
        public string description { get; private set; }

        public int atlasNumber { get; private set; }

        [JsonProperty("skinSort")]
        public int sort { get; private set; }

        public string thumbnail { get; private set; }

        public string resource { get; private set; }

        public string priceType { get; private set; }

        public int price { get; private set; }

        public string accessory { get; private set; }

        public GoodsDataRow goodsDr
        {
            get
            {
                if (_goodsDr == null)
                {
                    _goodsDr = Constants.regulation.goodsDtbl[priceType];
                }
                return _goodsDr;
            }
        }

        public string GetKey()
        {
            return id;
        }
    }

}
