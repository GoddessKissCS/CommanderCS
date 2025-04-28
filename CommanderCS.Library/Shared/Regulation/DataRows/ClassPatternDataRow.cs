using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Shared.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class ClassPatternDataRow : DataRow
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