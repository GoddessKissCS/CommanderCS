using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Shared.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class DropGoldPatternDataRow : DataRow
    {
        public int key { get; private set; }

        public int levelStep { get; private set; }

        public int goldStep { get; private set; }

        public string GetKey()
        {
            return key.ToString();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}