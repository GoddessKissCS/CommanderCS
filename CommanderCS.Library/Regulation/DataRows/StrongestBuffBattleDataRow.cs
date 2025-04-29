using CommanderCS.Library.Enums;
using CommanderCS.Library.Regulation;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class StrongestBuffBattleDataRow : DataRow
    {
        public string idx { get; private set; }

        public EWorldDuelBuff buffTarget { get; private set; }

        public int buffLevel { get; private set; }

        public int buffType { get; private set; }

        public int buffAdd { get; private set; }

        public EWorldDuelBuffEffect buffEffectType { get; private set; }

        public int upgradeCoin { get; private set; }

        public string GetKey()
        {
            return idx;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}