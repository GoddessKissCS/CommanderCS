using StellarGKLibrary.Enums;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class StatusEffectDataRow : DataRow
	{
		private StatusEffectDataRow()
		{
		}

		public string key { get; set; }

		public string pfbName { get; set; }

		public string thumbnail { get; set; }

		public int group { get; set; }

		public int chance { get; set; }

		public int targetJobType { get; set; }

		public int targetAttackerScale { get; set; }

		public int targetDefenderScale { get; set; }

		public int targetSupporterScale { get; set; }

		public int unbeatableVal { get; set; }

		public int silenceVal { get; set; }

		public int stunVal { get; set; }

		public int aggroVal { get; set; }

		public int spVal { get; set; }

		public int dotDamage { get; set; }

		public int dotHealing { get; set; }

		[JsonProperty("shield")]
		public int shield { get; set; }

		[JsonProperty("shldCn")]
		public int shieldCount { get; set; }

		[JsonProperty("atkPt")]
		public bool attackPoint { get; set; }

		[JsonProperty("fixEsn")]
		public int fixedEvasionRate { get; set; }

		public int damageCutRate { get; set; }

		[JsonProperty("dmgRecov")]
		public int damageRecoveryRate { get; set; }

		[JsonProperty("rmStCn")]
		public int removeStatusCount { get; set; }

		[JsonProperty("rmStGp")]
		public int removeStatusGroup { get; set; }

		[JsonProperty("rmStTn")]
		public int removeStatusTurn { get; set; }

		[JsonProperty("rmStStl")]
		public int removeStatusSteal { get; set; }

		[JsonProperty("rmStStlTn")]
		public int removeStatusStealTurn { get; set; }

		[JsonProperty("pvStGp")]
		public int preventStatusGroup { get; set; }

		[JsonProperty("pvRate")]
		public int preventStatusRate { get; set; }

		public int maxHealthBonus { get; set; }

		public int speedBonus { get; set; }

		public int accuracyBonus { get; set; }

		public int luckBonus { get; set; }

		public int attackDamageBonus { get; set; }

		public int defenseBonus { get; set; }

		public int criticalChanceBonus { get; set; }

		public int criticalDamageBonus { get; set; }

		public int recvHealBonus { get; set; }

		public string GetKey()
		{
			return key;
		}

		public const int unbeatableGroup = 128;
	}
}
