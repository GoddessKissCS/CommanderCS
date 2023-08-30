using StellarGKLibrary.Enums;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class SkillDamagePatternDataRow : DataRow
	{
		public int key { get; set; }

		[JsonProperty("motionSetId")]
		public int maxHpRate { get; set; }

		[JsonProperty("splashPattern")]
		public int minHpRate { get; set; }

		[JsonProperty("hpDamageScale")]
		public int damageScale { get; set; }

		public string GetKey()
		{
			return string.Empty;
		}
	}
}
