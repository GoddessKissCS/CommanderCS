using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class EnemyUnitDataRow : DataRow
	{
		private EnemyUnitDataRow()
		{
		}

		public int index { get; private set; }

		public string id { get; private set; }

		public int wave { get; private set; }

		public string unitId { get; private set; }

		public int unitLevel { get; private set; }

		public int unitPosition { get; private set; }

		public int unitGrade { get; private set; }

		public int unitClass { get; private set; }

		public List<int> skillLevel { get; private set; }

		public int unitScale { get; private set; }

		public string GetKey()
		{
			return index.ToString();
		}
	}
}
