using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Shared.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class ScenarioQuarterDataRow : DataRow
    {
        public string csid;

        public string quarter;

        public string GetKey()
        {
            return quarter.ToString();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}