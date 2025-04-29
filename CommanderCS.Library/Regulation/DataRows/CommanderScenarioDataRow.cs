using CommanderCS.Library.Regulation;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class CommanderScenarioDataRow : DataRow
    {
        public int csid { get; private set; }

        public string cid { get; private set; }

        public int order { get; private set; }

        public string name { get; private set; }

        public string desc { get; private set; }

        public int level { get; private set; }

        public int grade { get; private set; }

        public int cls { get; private set; }

        public int favor { get; private set; }

        public int mapClear { get; private set; }

        public int commander { get; private set; }

        public int scenarioClear { get; private set; }

        public int heart { get; private set; }

        public string GetKey()
        {
            return csid.ToString();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}