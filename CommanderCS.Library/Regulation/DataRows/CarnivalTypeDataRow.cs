using CommanderCS.Library.Enums;
using CommanderCS.Library.Regulation;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class CarnivalTypeDataRow : DataRow
    {
        public string idx { get; private set; }

        public string name { get; private set; }

        public int sort { get; private set; }

        public ECarnivalType Type { get; private set; }

        public string startDate { get; private set; }

        public string startTime { get; private set; }

        public string endDate { get; private set; }

        public string endTime { get; private set; }

        public int startLevel { get; private set; }

        public int endLevel { get; private set; }

        public int etc { get; private set; }

        public string img { get; private set; }

        public ECarnivalCategory categoryType { get; private set; }

        private CarnivalTypeDataRow()
        {
        }

        public string GetKey()
        {
            return idx;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}