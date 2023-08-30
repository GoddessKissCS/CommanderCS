using StellarGKLibrary.Enums;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class SkillUpgradeDataRow : DataRow
	{
		private SkillUpgradeDataRow()
		{
		}

		public string key { get; set; }

		public int levelLimit { get; set; }

		public int attackDamage { get; set; }

		[JsonProperty("atkDmIgDfn")]
		public int attackDamageIgnoreDefense { get; set; }

		[JsonProperty("IgDfnRate")]
		public int defensePenetrationRate { get; set; }

		public int healing { get; set; }

		public int shieldBonus { get; set; }

		[JsonProperty("shldCn")]
		public int shieldCount { get; set; }

		public int bloodsucking { get; set; }

		[JsonProperty("rmStTp")]
		public int removeStatusCount { get; set; }

		[JsonProperty("rmStTn")]
		public int removeStatusTurn { get; set; }

		[JsonProperty("pvRate")]
		public int preventStatusRate { get; set; }

		public int projectileTargetAttackerScale { get; set; }

		public int projectileTargetDefenderScale { get; set; }

		public int projectileTargetSupporterScale { get; set; }

		public int buffTargetAttackerScale { get; set; }

		public int buffTargetDefenderScale { get; set; }

		public int buffTargetSupporterScale { get; set; }

		public int spVal { get; set; }

		public int dotDamage { get; set; }

		public int dotHealing { get; set; }

		public int attackDamageBonus { get; set; }

		public int recvHealBonus { get; set; }

		public int maxHealthBonus { get; set; }

		public int speedBonus { get; set; }

		public int accuracyBonus { get; set; }

		public int luckBonus { get; set; }

		public int defenseBonus { get; set; }

		public int criticalChanceBonus { get; set; }

		public int criticalDamageBonus { get; set; }

		[JsonProperty("fixEsn")]
		public int fixedEvasionRate { get; set; }

		[JsonProperty("dmgRecov")]
		public int damageRecoveryRate { get; set; }

		public string GetKey()
		{
			return key;
		}
	}
}
