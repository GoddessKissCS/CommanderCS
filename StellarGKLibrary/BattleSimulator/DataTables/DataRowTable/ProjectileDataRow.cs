using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class ProjectileDataRow : DataRow
	{
		private ProjectileDataRow()
		{
		}

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
