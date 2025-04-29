using CommanderCS.Library.Enums;
using CommanderCS.Library.Regulation;
using Newtonsoft.Json;

namespace CommanderCS.Library.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class EventBattleScenarioDataRow : DataRow
    {
        public string eventIdx { get; private set; }

        public int playTurn { get; private set; }

        public string eventType { get; private set; }

        public EventScenarioTimingType timing { get; private set; }

        public string scenarioIdx { get; private set; }

        public string title { get; private set; }

        public int mapClear { get; private set; }

        public int sort { get; private set; }

        public string GetKey()
        {
            return eventIdx + playTurn;
        }
    }
}