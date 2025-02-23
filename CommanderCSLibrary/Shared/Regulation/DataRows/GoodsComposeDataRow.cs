using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCSLibrary.Shared.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class GoodsComposeDataRow : DataRow
    {
        public string idx { get; private set; }

        public string composeIdx { get; private set; }

        public int value { get; private set; }

        public string rewardIdx { get; private set; }

        public int rewardValue { get; private set; }

        public string GetKey()
        {
            return composeIdx;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}