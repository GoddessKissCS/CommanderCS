using CommanderCSLibrary.Shared.Enum;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation
{
    [Serializable]
    [JsonObject]
    public class GoodsRechargeCashDataRow : DataRow
    {
        public int index { get; private set; }

        public EGoods goods { get; private set; }

        public int repeatCount { get; private set; }

        public int cash { get; private set; }

        public string GetKey()
        {
            return index.ToString();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}

