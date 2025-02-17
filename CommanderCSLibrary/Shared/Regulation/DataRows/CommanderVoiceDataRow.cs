using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCSLibrary.Shared.Regulation.DataRows
{
    [Serializable]
    public class CommanderVoiceDataRow : DataRow
    {
        public string index { get; private set; }

        public ECommanderVoiceEventType type { get; private set; }

        [JsonProperty("voicesound")]
        public string sound { get; private set; }

        private CommanderVoiceDataRow()
        {
        }

        public string GetKey()
        {
            return $"{index}_{(int)type}";
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}