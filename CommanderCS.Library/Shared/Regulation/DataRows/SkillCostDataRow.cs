using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Shared.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class SkillCostDataRow : DataRow
    {
        public List<int> typeCost;

        public List<int> typeLimitLevel;

        public int level { get; private set; }

        public string GetKey()
        {
            return level.ToString();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}