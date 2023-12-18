using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCSLibrary.Shared.Regulation
{
    [Serializable]
    [JsonObject]
    public class CommanderTrainingTicketDataRow : DataRow
    {
        public ETrainingTicketType type { get; private set; }

        public int gold { get; private set; }

        public int exp { get; private set; }

        public string GetKey()
        {
            return type.ToString();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}