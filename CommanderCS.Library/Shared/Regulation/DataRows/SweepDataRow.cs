using CommanderCS.Library.Shared.Enum;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Shared.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class SweepDataRow : DataRow
    {
        public int index;

        public int type { get; private set; }

        public int level { get; private set; }

        public string name { get; private set; }

        public string description { get; private set; }

        public int minLevel { get; private set; }

        public EGoods gid { get; private set; }

        public int useValue { get; private set; }

        public int battleType { get; private set; }

        public string helper { get; private set; }

        public string uid { get; private set; }

        public string battlemap { get; private set; }

        public string enemymap { get; private set; }

        public string bgm { get; private set; }

        public int endTurn { get; private set; }

        public string GetKey()
        {
            return $"{type}_{level}";
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}