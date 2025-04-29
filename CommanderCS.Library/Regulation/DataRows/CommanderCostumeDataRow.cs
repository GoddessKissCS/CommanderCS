using CommanderCS.Library.Enums;
using CommanderCS.Library.Regulation;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class CommanderCostumeDataRow : DataRow
    {
        public int ctid { get; private set; }

        public int cid { get; private set; }

        public string name { get; private set; }

        public string Desc { get; private set; }

        public int sell { get; private set; }

        public EPriceType gid { get; private set; }

        public int sellPrice { get; private set; }

        public string skinName { get; private set; }

        public int order { get; private set; }

        public StatType statType1 { get; private set; }

        public int stat1 { get; private set; }

        public StatType statType2 { get; private set; }

        public int stat2 { get; private set; }

        public StatType statType3 { get; private set; }

        public int stat3 { get; private set; }

        public int atlasNumber { get; private set; }

        public string GetKey()
        {
            return ctid.ToString();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}