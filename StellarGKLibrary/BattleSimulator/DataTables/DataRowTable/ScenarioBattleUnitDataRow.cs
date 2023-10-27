using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;


namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class ScenarioBattleUnitDataRow : DataRow
	{
		public string battleIdx { get; private set; }

		public int uType { get; private set; }

		public string unitId { get; private set; }

		public int unitLevel { get; private set; }

		public int unitPosition { get; private set; }

		public int unitGrade { get; private set; }

		public int unitClass { get; private set; }

		public List<int> skillLevel { get; private set; }

		public string GetKey()
		{
			return string.Format("{0}_{1}_{2}", battleIdx, unitId, unitPosition);
		}
	}
}
