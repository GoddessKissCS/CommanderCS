using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCSLibrary.Shared.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class FavorDataRow : DataRow
    {
        public int cid { get; private set; }

        public int step { get; private set; }

        public string profile { get; private set; }

        public StatType statType { get; private set; }

        public int stat { get; private set; }

        public string GetKey()
        {
            return cid.ToString();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}