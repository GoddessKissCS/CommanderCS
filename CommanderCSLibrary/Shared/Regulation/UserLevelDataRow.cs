using CommanderCSLibrary.Shared.Enum;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation
{
    [Serializable]
    [JsonObject]
    public class UserLevelDataRow : DataRow
    {
        public int level { get; private set; }

        public int exp { get; private set; }

        public int uExp { get; private set; }

        public int maxBullet { get; private set; }

        public int maxSkill { get; private set; }

        public int rewardBullet { get; private set; }

        public int bankGold { get; private set; }

        public float goldIncrease { get; private set; }

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