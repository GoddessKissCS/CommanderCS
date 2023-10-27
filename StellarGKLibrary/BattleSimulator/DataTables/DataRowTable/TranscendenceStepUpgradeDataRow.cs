using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class TranscendenceStepUpgradeDataRow : DataRow
	{
		public int step { get; private set; }

		public int stepPoint { get; private set; }

		public StatType stat { get; private set; }

		public int statAddMeasure { get; private set; }

		public int statAddVolume { get; private set; }

		public string addString { get; private set; }

		public string GetKey()
		{
			return step.ToString();
		}

	}
}
