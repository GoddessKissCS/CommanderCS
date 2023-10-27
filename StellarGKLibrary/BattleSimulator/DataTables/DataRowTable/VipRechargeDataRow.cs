using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class VipRechargeDataRow : DataRow
	{
		public string idx { get; private set; }

		public int type { get; private set; }

		public int typeIndex { get; private set; }

		public int startVip { get; private set; }

		public int startRecharge { get; private set; }

		public int vipMeasure { get; private set; }

		public int rechargeAddPoint { get; private set; }

		public int startRechargePrice { get; private set; }

		public int numberMeasure { get; private set; }

		public int priceAddPercent { get; private set; }

		public int rechargeAmount { get; private set; }

		public string GetKey()
		{
			return idx;
		}

		public int GetMaxRechargeCount(int currentVip)
		{
			return (currentVip - startVip) / vipMeasure * rechargeAddPoint + startRecharge;
		}

	}
}
