using CommanderCSLibrary.Shared.Enum;
using System.Runtime.Serialization;
using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation
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