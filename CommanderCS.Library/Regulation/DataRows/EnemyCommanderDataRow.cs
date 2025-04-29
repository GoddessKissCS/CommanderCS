using CommanderCS.Library.Regulation;
using Newtonsoft.Json;

namespace CommanderCS.Library.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class EnemyCommanderDataRow : DataRow
    {
        public int index { get; private set; }

        public string id { get; private set; }

        public int wave { get; private set; }

        public string commanderId { get; private set; }

        public int commanderRank { get; private set; }

        public string name { get; private set; }

        public int power { get; private set; }

        private EnemyCommanderDataRow()
        {
        }

        public string GetKey()
        {
            return id;
        }
    }
}