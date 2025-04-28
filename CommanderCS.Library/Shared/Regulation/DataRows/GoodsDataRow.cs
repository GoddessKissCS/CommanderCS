using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCSLibrary.Shared.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class GoodsDataRow : DataRow
    {
        [JsonProperty("rechargeCost")]
        private List<int> _rechargeCost;

        public string type { get; private set; }

        [JsonIgnore]
        public EGoods gType { get; private set; }

        public int max { get; private set; }

        public EGoodsRechargeType rechargeType { get; private set; }

        public int rechargeMax { get; private set; }

        [JsonIgnore]
        public IList<int> rechargeCost => _rechargeCost.AsReadOnly();

        public string resourceId => type.ToString();

        public string serverFieldName { get; private set; }

        public string name { get; private set; }

        public string description { get; private set; }

        public bool storage { get; private set; }

        public int rechargeTime { get; private set; }

        public string icon { get; private set; }

        public int openType { get; private set; }

        [JsonIgnore]
        public string iconId => icon;

        [JsonIgnore]
        public bool isBox => openType == 1;

        private GoodsDataRow()
        {
        }

        public string GetKey()
        {
            return type;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            Regulation.FillList(ref _rechargeCost, 15);
        }
    }
}