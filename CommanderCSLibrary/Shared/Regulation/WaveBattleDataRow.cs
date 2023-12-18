using CommanderCSLibrary.Shared.Enum;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation
{
    [Serializable]
    [JsonObject]
    public class WaveBattleDataRow : DataRow
    {
        public string idx { get; private set; }

        public string name { get; private set; }

        public string thumbnail { get; private set; }

        public string explanation { get; private set; }

        public int helper { get; private set; }

        public int enemy { get; private set; }

        public int endTurn { get; private set; }

        public string battlemap { get; private set; }

        public string enemymap { get; private set; }

        public string bgm { get; private set; }

        public List<int> enter { get; private set; }

        public string GetKey()
        {
            return idx;
        }
    }
}
