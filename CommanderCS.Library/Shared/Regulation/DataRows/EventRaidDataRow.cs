using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Shared.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class EventRaidDataRow : DataRow
    {
        public string idx { get; private set; }

        public string eventIdx { get; private set; }

        public string raidIdx { get; private set; }

        public int endTurn { get; private set; }

        public string battleMap { get; private set; }

        public string enemyMap { get; private set; }

        public string GetKey()
        {
            return $"{eventIdx}_{raidIdx}";
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}