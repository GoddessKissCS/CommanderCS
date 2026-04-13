using CommanderCS.Library.Regulation;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class RandomGachaRewardDataRow : DataRow
    {
        public int BoxId { get; private set; }

        public int RewardType { get; private set; }

        public int RewardId { get; private set; }

        public int Count { get; private set; }

        private RandomGachaRewardDataRow()
        {
        }

        public string GetKey()
        {
            return BoxId.ToString();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}
