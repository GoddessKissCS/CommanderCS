using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Ro;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CommanderCSLibrary.Shared.Regulation.DataRows
{
    [Obsolete("deleted")]
    [JsonObject]
    public class UnitRankDataRow : DataRow
    {
        public string id { get; private set; }

        public string name { get; private set; }

        public int rank { get; private set; }

        public string resourceId { get; private set; }

        public EBranch branch { get; private set; }

        public int operatingCostGold { get; private set; }

        public int leadership { get; private set; }

        public int maxHealth { get; private set; }

        public int attackDamage { get; private set; }

        public int defense { get; private set; }

        public int accuracy { get; private set; }

        public int evasion { get; private set; }

        public int criticalChance { get; private set; }

        public int criticalDamage { get; private set; }

        public int reloadSpeed { get; private set; }

        public int levelUpDuration { get; private set; }

        public int levelUpCostGold { get; private set; }

        public int levelUpCostBlueprint { get; private set; }

        public int rankUpDuration { get; private set; }

        public int rankUpCostGold { get; private set; }

        public int rankUpCostBlueprint { get; private set; }

        public RoTroop.Ability[] troopAbilities { get; private set; }

        public string GetKey()
        {
            return id;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
        }
    }
}