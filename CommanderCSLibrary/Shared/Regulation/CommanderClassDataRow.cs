using CommanderCSLibrary.Shared.Enum;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation {

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
