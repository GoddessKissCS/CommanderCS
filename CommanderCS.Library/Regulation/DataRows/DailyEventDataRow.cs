using CommanderCS.Library.Enums;
using CommanderCS.Library.Regulation;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class DailyEventDataRow : DataRow
    {
        public string id { get; private set; }

        public EWeekType week { get; private set; }

        public string start { get; private set; }

        public int time { get; private set; }

        public int type { get; private set; }

        public string name { get; private set; }

        public string GetKey()
        {
            return ((int)week).ToString();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}