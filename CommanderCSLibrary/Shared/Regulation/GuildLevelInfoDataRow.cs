using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCSLibrary.Shared.Regulation
{
    [Serializable]
    [JsonObject]
    public class GuildLevelInfoDataRow : DataRow
    {
        public int level { get; private set; }

        public int maxcount { get; private set; }

        public int cost { get; private set; }

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