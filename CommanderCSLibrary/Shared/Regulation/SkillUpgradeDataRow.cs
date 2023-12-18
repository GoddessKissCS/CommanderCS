using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation
{
    [Serializable]
    [JsonObject]
    public class SkillUpgradeDataRow : DataRow
    {
        public string key { get; private set; }

        public int levelLimit { get; private set; }

        public int attackDamage { get; private set; }

        [JsonProperty("atkDmIgDfn")]
        public int attackDamageIgnoreDefense { get; private set; }

        [JsonProperty("IgDfnRate")]
        public int defensePenetrationRate { get; private set; }

        public int healing { get; private set; }

        public int shieldBonus { get; private set; }

        [JsonProperty("shldCn")]
        public int shieldCount { get; private set; }

        public int bloodsucking { get; private set; }

        [JsonProperty("rmStTp")]
        public int removeStatusCount { get; private set; }

        [JsonProperty("rmStTn")]
        public int removeStatusTurn { get; private set; }

        [JsonProperty("pvRate")]
        public int preventStatusRate { get; private set; }

        public int projectileTargetAttackerScale { get; private set; }

        public int projectileTargetDefenderScale { get; private set; }

        public int projectileTargetSupporterScale { get; private set; }

        public int buffTargetAttackerScale { get; private set; }

        public int buffTargetDefenderScale { get; private set; }

        public int buffTargetSupporterScale { get; private set; }

        public int spVal { get; private set; }

        public int dotDamage { get; private set; }

        public int dotHealing { get; private set; }

        public int attackDamageBonus { get; private set; }

        public int recvHealBonus { get; private set; }

        public int maxHealthBonus { get; private set; }

        public int speedBonus { get; private set; }

        public int accuracyBonus { get; private set; }

        public int luckBonus { get; private set; }

        public int defenseBonus { get; private set; }

        public int criticalChanceBonus { get; private set; }

        public int criticalDamageBonus { get; private set; }

        [JsonProperty("fixEsn")]
        public int fixedEvasionRate { get; private set; }

        [JsonProperty("dmgRecov")]
        public int damageRecoveryRate { get; private set; }

        private SkillUpgradeDataRow()
        {
        }

        public string GetKey()
        {
            return key;
        }
    }

}