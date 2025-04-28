using CommanderCS.Library.Shared.Enum;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Shared.Regulation.DataRows
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