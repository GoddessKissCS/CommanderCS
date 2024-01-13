using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCSLibrary.Shared.Regulation
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