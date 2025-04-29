using CommanderCS.Library.Enums;
using CommanderCS.Library.Regulation;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCS.Library.Regulation.DataRows
{
    [Serializable]
    [JsonObject]
    public class ProjectileDataRow : DataRow
    {
        public const int StatusEffectCount = 2;

        [JsonProperty("clingingTurn")]
        private List<int> _clingingTurns;

        [JsonProperty("statusEffectDrks")]
        private List<string> _statusEffectDrks;

        public string key { get; private set; }

        public string motionSetId { get; private set; }

        public string splashPattern { get; private set; }

        public bool shouldRenderSplash { get; private set; }

        public int accuracyScale { get; private set; }

        public int attackDamageScale { get; private set; }

        public int criticalChanceScale { get; private set; }

        public int depletionScale { get; private set; }

        public int healingScale { get; private set; }

        public EProjectileTargetScaleType targetScaleType { get; private set; }

        public int targetAttackerScale { get; private set; }

        public int targetDefenderScale { get; private set; }

        public int targetSupporterScale { get; private set; }

        [JsonProperty("dmPtn")]
        public int damagePattern { get; private set; }

        public int clingingTime { get; private set; }

        [JsonIgnore]
        public IList<int> clingingTurns => _clingingTurns.AsReadOnly();

        [JsonIgnore]
        public IList<string> statusEffectDrks => _statusEffectDrks.AsReadOnly();

        private ProjectileDataRow()
        {
        }

        public string GetKey()
        {
            return key;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            Regulation.FillList(ref _statusEffectDrks, 2);
            Regulation.FillList(ref _clingingTurns, 2);
        }
    }
}