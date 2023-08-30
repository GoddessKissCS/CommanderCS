using StellarGKLibrary.Enums;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class ProjectileDataRow : DataRow
	{
		private ProjectileDataRow()
		{
		}

		public string key { get; set; }

		public string motionSetId { get; set; }

		public string splashPattern { get; set; }

		public bool shouldRenderSplash { get; set; }

		public int accuracyScale { get; set; }

		public int attackDamageScale { get; set; }

		public int criticalChanceScale { get; set; }

		public int depletionScale { get; set; }

		public int healingScale { get; set; }

		public EProjectileTargetScaleType targetScaleType { get; set; }

		public int targetAttackerScale { get; set; }

		public int targetDefenderScale { get; set; }

		public int targetSupporterScale { get; set; }

		[JsonProperty("dmPtn")]
		public int damagePattern { get; set; }

		public int clingingTime { get; set; }

		[JsonIgnore]
		public IList<int> clingingTurns
		{
			get
			{
				return _clingingTurns.AsReadOnly();
			}
		}

		[JsonIgnore]
		public IList<string> statusEffectDrks
		{
			get
			{
				return _statusEffectDrks.AsReadOnly();
			}
		}

		public string GetKey()
		{
			return key;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			Regulation.FillList<string>(ref _statusEffectDrks, 2);
			Regulation.FillList<int>(ref _clingingTurns, 2);
		}

		public const int StatusEffectCount = 2;

		[JsonProperty("clingingTurn")]
		private List<int> _clingingTurns;

		[JsonProperty("statusEffectDrks")]
		private List<string> _statusEffectDrks;
	}
}
