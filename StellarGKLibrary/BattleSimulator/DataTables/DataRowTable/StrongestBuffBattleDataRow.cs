using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class StrongestBuffBattleDataRow : DataRow
	{
		public string idx { get; private set; }

		public EWorldDuelBuff buffTarget { get; private set; }

		public int buffLevel { get; private set; }

		public int buffType { get; private set; }

		public int buffAdd { get; private set; }

		public EWorldDuelBuffEffect buffEffectType { get; private set; }

		public int upgradeCoin { get; private set; }

		public string GetKey()
		{
			return idx;
		}

	}
}
