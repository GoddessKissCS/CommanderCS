using CommanderCS.Library.Enums;
using CommanderCS.Library.Regulation;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class GachaCostDataRow : DataRow
    {
        public string index { get; private set; }

        public string type { get; private set; }

        public int count { get; private set; }

        public EGoods priceType { get; private set; }

        public int cost { get; private set; }

        public string GetKey()
        {
            return index;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}