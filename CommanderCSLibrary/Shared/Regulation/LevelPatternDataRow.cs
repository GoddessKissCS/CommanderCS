using CommanderCSLibrary.Shared.Enum;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation
{
    [Serializable]
    [JsonObject]
    public class LevelPatternDataRow : DataRow
    {
        public int key { get; private set; }

        public int tier { get; private set; }

        public int hp { get; private set; }

        public int atk { get; private set; }

        public int def { get; private set; }

        public int aim { get; private set; }

        public int luck { get; private set; }

        public string GetKey()
        {
            return $"{key}_{tier}";
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }

}
