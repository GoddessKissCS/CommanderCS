using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCSLibrary.Shared.Regulation
{
    [Serializable]
    [JsonObject]
    public class CarnivalDataRow : DataRow
    {
        public string key { get; private set; }

        public string idx { get; private set; }

        public string cTidx { get; private set; }

        public string explanation { get; private set; }

        public int checkType { get; private set; }

        public int checkCount { get; private set; }

        public string check2 { get; private set; }

        public string link { get; private set; }

        public int userVip { get; private set; }

        public int userLevel { get; private set; }

        public ERewardType commodityType { get; private set; }

        public string commodityIdx { get; private set; }

        public int commodityCount { get; private set; }

        public string aidExplanation { get; private set; }

        public EventCarnivalCheckType check2Type { get; private set; }

        private CarnivalDataRow()
        {
        }

        public string GetKey()
        {
            return key;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}