using CommanderCSLibrary.Shared.Enum;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation
{

    [Serializable]
    [JsonObject]
    public class ShopItemDataRow : DataRow
    {
        public string id { get; private set; }

        public string resourceId { get; private set; }

        public string marketItemId { get; private set; }

        public EShopItemType type { get; private set; }

        public int gold { get; private set; }

        public int cash { get; private set; }

        public string description { get; private set; }

        private ShopItemDataRow()
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