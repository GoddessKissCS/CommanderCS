using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Shared.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class CommanderLevelDataRow : DataRow
    {
        public int level { get; private set; }

        public int exp { get; private set; }

        public int aexp { get; private set; }

        public int AddLeadership { get; private set; }

        public string GetKey()
        {
            return level.ToString();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}