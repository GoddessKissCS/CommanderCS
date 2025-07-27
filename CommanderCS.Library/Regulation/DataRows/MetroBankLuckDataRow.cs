using CommanderCS.Library.Regulation;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class MetroBankLuckDataRow : DataRow
    {
        public string Luck { get; private set; }

        public int ChipPercent { get; private set; }

        public string GetKey()
        {
            return Luck;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}