using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCSLibrary.Shared.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class GuildOccupyDataRow : DataRow
    {
        public string idx { get; private set; }

        public string s_idx { get; private set; }

        public string symbol { get; private set; }

        public int stageType { get; private set; }

        public int positionx { get; private set; }

        public int positiony { get; private set; }

        public int crossRoads { get; private set; }

        public List<int> next { get; private set; }

        public List<int> nexttime { get; private set; }

        public int oPoint { get; private set; }

        public int rewardType { get; private set; }

        public string rewardIdx { get; private set; }

        public int rewardCount { get; private set; }

        public string building { get; private set; }

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