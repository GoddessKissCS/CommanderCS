using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCSLibrary.Shared.Regulation
{
    [Serializable]
    [JsonObject]
    public class TranscendenceSlotDataRow : DataRow
    {
        public int slot { get; private set; }

        public StatType stat { get; private set; }

        public int addStat { get; private set; }

        public int firstStepLimit { get; private set; }

        public int addStepLimit { get; private set; }

        public string statString { get; private set; }

        public string icon { get; private set; }

        public string tip { get; private set; }

        public string tipTitle { get; private set; }

        public string GetKey()
        {
            return slot.ToString();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}