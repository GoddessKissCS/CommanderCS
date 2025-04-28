using CommanderCS.Library.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCS.Library.Shared.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class DormitoryBodyCostumeDataRow : DataRow
    {
        private ItemExchangeDataRow _itemExchangeDr;

        [JsonProperty("ctid")]
        public string id { get; private set; }

        public string name { get; private set; }

        [JsonProperty("desc")]
        public string description { get; private set; }

        public int atlasNumber { get; private set; }

        [JsonProperty("skinSort")]
        public int sort { get; private set; }

        public string thumbnail { get; private set; }

        public string resource { get; private set; }

        public string decoIdx { get; private set; }

        public ItemExchangeDataRow itemExchangeDr
        {
            get
            {
                if (_itemExchangeDr is null)
                {
                    _itemExchangeDr = RemoteObjectManager.instance.regulation.itemExchangeDtbl.Find((item) => item.typeidx == id && item.type == EStorageType.DormitoryCostume);
                }
                return _itemExchangeDr;
            }
        }

        public string GetKey()
        {
            return id;
        }
    }
}