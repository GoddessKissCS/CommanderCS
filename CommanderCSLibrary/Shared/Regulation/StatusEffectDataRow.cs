using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation;

[Serializable]
[JsonObject]
public class StatusEffectDataRow : DataRow
{
	public const int unbeatableGroup = 128;

	public string key { get; private set; }

	public string pfbName { get; private set; }

	public string thumbnail { get; private set; }

	public int group { get; private set; }

	public int chance { get; private set; }

	public int targetJobType { get; private set; }

	public int targetAttackerScale { get; private set; }

	public int targetDefenderScale { get; private set; }

	public int targetSupporterScale { get; private set; }

	public int unbeatableVal { get; private set; }

	public int silenceVal { get; private set; }

	public int stunVal { get; private set; }

	public int aggroVal { get; private set; }

	public int spVal { get; private set; }

	public int dotDamage { get; private set; }

	public int dotHealing { get; private set; }

	[JsonProperty("shield")]
	public int shield { get; private set; }

	[JsonProperty("shldCn")]
	public int shieldCount { get; private set; }

	[JsonProperty("atkPt")]
	public bool attackPoint { get; private set; }

	[JsonProperty("fixEsn")]
	public int fixedEvasionRate { get; private set; }

	public int damageCutRate { get; private set; }

	[JsonProperty("dmgRecov")]
	public int damageRecoveryRate { get; private set; }

	[JsonProperty("rmStCn")]
	public int removeStatusCount { get; private set; }

	[JsonProperty("rmStGp")]
	public int removeStatusGroup { get; private set; }

	[JsonProperty("rmStTn")]
	public int removeStatusTurn { get; private set; }

	[JsonProperty("rmStStl")]
	public int removeStatusSteal { get; private set; }

	[JsonProperty("rmStStlTn")]
	public int removeStatusStealTurn { get; private set; }

	[JsonProperty("pvStGp")]
	public int preventStatusGroup { get; private set; }

	[JsonProperty("pvRate")]
	public int preventStatusRate { get; private set; }

	public int maxHealthBonus { get; private set; }

	public int speedBonus { get; private set; }

	public int accuracyBonus { get; private set; }

	public int luckBonus { get; private set; }

	public int attackDamageBonus { get; private set; }

	public int defenseBonus { get; private set; }

	public int criticalChanceBonus { get; private set; }

	public int criticalDamageBonus { get; private set; }

	public int recvHealBonus { get; private set; }

	private StatusEffectDataRow()
	{
	}

	public string GetKey()
	{
		return key;
	}
}
