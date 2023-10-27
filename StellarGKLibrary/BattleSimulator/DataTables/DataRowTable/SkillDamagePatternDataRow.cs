using System;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class SkillDamagePatternDataRow : DataRow
	{
		public int key { get; private set; }

		[JsonProperty("motionSetId")]
		public int maxHpRate { get; private set; }

		[JsonProperty("splashPattern")]
		public int minHpRate { get; private set; }

		[JsonProperty("hpDamageScale")]
		public int damageScale { get; private set; }

		public string GetKey()
		{
			return string.Empty;
		}
	}
}
