using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class CommanderClassDataRow : DataRow
	{
		public int index { get; private set; }

		public int cls { get; private set; }

		public int level { get; private set; }

		public int limitedCmdLevel
		{
			get
			{
				return level;
			}
		}

		public int gold { get; private set; }

		public Dictionary<string, int> pidx { get; private set; }

		public Dictionary<string, int> pvalue { get; private set; }

		public string GetKey()
		{
			return index.ToString();
		}

	}
}
