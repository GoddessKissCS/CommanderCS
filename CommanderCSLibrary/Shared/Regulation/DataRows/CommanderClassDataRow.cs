using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCSLibrary.Shared.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class CommanderClassDataRow : DataRow
    {
        public int index { get; private set; }

        public int cls { get; private set; }

        public int level { get; private set; }

        public int limitedCmdLevel => level;

        public int gold { get; private set; }

        public Dictionary<string, int> pidx { get; private set; }

        public Dictionary<string, int> pvalue { get; private set; }

        public string GetKey()
        {
            return index.ToString();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}