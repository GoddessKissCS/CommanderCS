using CommanderCSLibrary.Shared.Enum;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation
{
    [Serializable]
    [JsonObject]
    public class CommanderGiftDataRow : DataRow
    {
        public int idx { get; private set; }

        public int type { get; private set; }

        public int favorPoint { get; private set; }

        public string GetKey()
        {
            return idx.ToString();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}
