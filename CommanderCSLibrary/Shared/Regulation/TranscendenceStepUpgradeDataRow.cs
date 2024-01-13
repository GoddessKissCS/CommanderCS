using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCSLibrary.Shared.Regulation
{
    [Serializable]
    [JsonObject]
    public class TranscendenceStepUpgradeDataRow : DataRow
    {
        public int step { get; private set; }

        public int stepPoint { get; private set; }

        public StatType stat { get; private set; }

        public int statAddMeasure { get; private set; }

        public int statAddVolume { get; private set; }

        public string addString { get; private set; }

        public string GetKey()
        {
            return step.ToString();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}