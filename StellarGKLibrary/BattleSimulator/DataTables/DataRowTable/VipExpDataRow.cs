using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class VipExpDataRow : DataRow
	{
		public int Idx { get; private set; }

		public int exp { get; private set; }

		public int favormax { get; private set; }

		public int maxSkill { get; private set; }

		public string GetKey()
		{
			return Idx.ToString();
		}

	}
}
