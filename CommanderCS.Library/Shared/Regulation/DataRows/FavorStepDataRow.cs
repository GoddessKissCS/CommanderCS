using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCSLibrary.Shared.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class FavorStepDataRow : DataRow
    {
        public int step { get; private set; }

        public int favor { get; private set; }

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