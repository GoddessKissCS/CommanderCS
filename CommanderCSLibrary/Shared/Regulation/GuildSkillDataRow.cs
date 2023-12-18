using CommanderCSLibrary.Shared.Enum;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation
{
    [Serializable]
    [JsonObject]
    public class GuildSkillDataRow : DataRow
    {
        public int idx { get; private set; }

        public int skilllevel { get; private set; }

        public int value { get; private set; }

        public int level { get; private set; }

        public int cost { get; private set; }

        public string name { get; private set; }

        public string description { get; private set; }

        public string GetKey()
        {
            return $"{idx}_{skilllevel}";
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }

}

