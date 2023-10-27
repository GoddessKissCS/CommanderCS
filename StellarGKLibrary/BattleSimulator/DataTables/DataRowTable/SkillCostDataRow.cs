using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class SkillCostDataRow : DataRow
	{
		public int level { get; private set; }

		public string GetKey()
		{
			return level.ToString();
		}

		public List<int> typeCost;

		public List<int> typeLimitLevel;
	}
}
