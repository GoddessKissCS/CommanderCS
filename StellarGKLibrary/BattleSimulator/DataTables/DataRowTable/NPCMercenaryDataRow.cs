using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class NPCMercenaryDataRow : DataRow
	{
		private NPCMercenaryDataRow()
		{
		}

		public string id { get; private set; }

		public int wave { get; private set; }

		public string unitId { get; private set; }

		public int unitLevel { get; private set; }

		public int unitGrade { get; private set; }

		public int unitClass { get; private set; }

		public List<int> skillLevel { get; private set; }

		public int unitScale { get; private set; }

		public string explanation { get; private set; }

		public string GetKey()
		{
			return id.ToString();
		}
	}
}
