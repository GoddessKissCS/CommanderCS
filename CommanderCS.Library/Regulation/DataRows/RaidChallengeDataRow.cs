using CommanderCS.Library.Regulation;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Regulation.DataRows
{
    [Serializable]
    public class RaidChallengeDataRow : DataRow
    {
        public const int PartsCount = 9;

        [JsonProperty("parts")]
        private List<string> _parts;

        [JsonProperty("partsPos")]
        private List<int> _partsPosition;

        public string key { get; private set; }

        public string commanderId { get; private set; }

        public int commanderPos { get; private set; }

        public string battlemap { get; private set; }

        public string enemymap { get; private set; }

        [JsonIgnore]
        public IList<string> parts => _parts.AsReadOnly();

        [JsonIgnore]
        public IList<int> partsPosition => _partsPosition.AsReadOnly();

        private RaidChallengeDataRow()
        {
        }

        public string GetKey()
        {
            return key;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            Regulation.FillList(ref _parts, 9);
            Regulation.FillList(ref _partsPosition, 9);
        }
    }
}