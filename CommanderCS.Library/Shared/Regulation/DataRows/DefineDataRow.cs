using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Shared.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class DefineDataRow : DataRow
    {
        public string key { get; private set; }

        public string value { get; private set; }

        public string GetKey()
        {
            return key;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}