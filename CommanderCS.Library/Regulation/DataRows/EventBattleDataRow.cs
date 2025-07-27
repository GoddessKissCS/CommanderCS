using CommanderCS.Library.Enums;
using CommanderCS.Library.Regulation;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class EventBattleDataRow : DataRow
    {
        public string eventIdx { get; private set; }

        public string goodsIdx { get; private set; }

        public int goodsAmount { get; private set; }

        public string eventImg { get; private set; }

        public string eventLogo { get; private set; }

        public ERewardType mainRewardType { get; private set; }

        public string mainRewardIdx { get; private set; }

        public int mainRewardAmount { get; private set; }

        public string eventPointIdx { get; private set; }

        public int gachaOneTimeAmount { get; private set; }

        public string GetKey()
        {
            return eventIdx;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}