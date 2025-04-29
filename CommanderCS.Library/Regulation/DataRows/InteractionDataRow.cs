using CommanderCS.Library.Enums;
using CommanderCS.Library.Regulation;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class InteractionDataRow : DataRow
    {
        public string resourceId { get; private set; }

        public InteractionType type { get; private set; }

        public int count { get; private set; }

        public string emotion { get; private set; }

        public string emoticon { get; private set; }

        public int balloon { get; private set; }

        public string S_Idx { get; private set; }

        public string sound { get; private set; }

        public int favorup { get; private set; }

        private string dialogue { get; set; }

        public string GetKey()
        {
            return resourceId.ToString();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            if (sound == "-")
            {
                sound = string.Empty;
            }
        }
    }
}