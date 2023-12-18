using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation
{
    [Serializable]
    [JsonObject]
    public class DormitoryDecorationDataRow : DataRow
    {
        private ItemExchangeDataRow _itemExchangeDr;

        [JsonProperty("type")]
        public string id { get; private set; }

        [JsonProperty("decoName")]
        public string name { get; private set; }

        public bool action { get; private set; }

        [JsonProperty("class")]
        public int advanced { get; private set; }

        [JsonProperty("image")]
        public string resource { get; private set; }

        public string thumbnail { get; private set; }

        public int atlasNumber { get; private set; }

        public int fixedSkin { get; private set; }

        public int actionRate { get; private set; }

        [JsonProperty("desc")]
        public string description { get; private set; }

        public string decoIdx { get; private set; }

        public int xSize { get; private set; }

        public int ySize { get; private set; }

        public ItemExchangeDataRow itemExchangeDr
        {
            get
            {
                if (_itemExchangeDr == null)
                {
                    _itemExchangeDr = Constants.regulation.itemExchangeDtbl.Find((ItemExchangeDataRow item) => item.typeidx == id && item.type == EStorageType.DormitoryFurniture);
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

