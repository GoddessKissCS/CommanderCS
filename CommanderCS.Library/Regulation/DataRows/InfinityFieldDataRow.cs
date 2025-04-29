using CommanderCS.Library.Enums;
using CommanderCS.Library.Regulation;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class InfinityFieldDataRow : DataRow
    {
        public string infinityFieldIdx { get; private set; }

        public EInfinityStageType type { get; private set; }

        public string name { get; private set; }

        public string explanation { get; private set; }

        public int scenarioIdx { get; private set; }

        public string enemy { get; private set; }

        public int endTurn { get; private set; }

        public string battleMap { get; private set; }

        public string enemyMap { get; private set; }

        public string bgm { get; private set; }

        public EBattleClearCondition clearMission01 { get; private set; }

        public string clearMission01Count { get; private set; }

        public EBattleClearCondition clearMission02 { get; private set; }

        public string clearMission02Count { get; private set; }

        public string GetKey()
        {
            return infinityFieldIdx;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}