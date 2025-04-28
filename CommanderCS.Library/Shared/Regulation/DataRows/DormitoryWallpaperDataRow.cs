using CommanderCS.Library.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCS.Library.Shared.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class DormitoryWallpaperDataRow : DataRow
    {
        private ItemExchangeDataRow _itemExchangeDr;

        [JsonProperty("type")]
        public string id { get; private set; }

        [JsonProperty("wallpaperName")]
        public string name { get; private set; }

        [JsonProperty("image")]
        public string resource { get; private set; }

        public string thumbnail { get; private set; }

        public int atlasNumber { get; private set; }

        [JsonProperty("desc")]
        public string description { get; private set; }

        public ItemExchangeDataRow itemExchangeDr
        {
            get
            {
                if (_itemExchangeDr is null)
                {
                    _itemExchangeDr = RemoteObjectManager.instance.regulation.itemExchangeDtbl.Find((item) => item.typeidx == id && item.type == EStorageType.DormitoryWallpaper);
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