using CommanderCS.Library.Enums;
using CommanderCS.Library.Regulation;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Regulation.DataRows
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