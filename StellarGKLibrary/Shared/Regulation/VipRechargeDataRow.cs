using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class VipRechargeDataRow : DataRow
	{
		public string idx { get; set; }

		public int type { get; set; }

		public int typeIndex { get; set; }

		public int startVip { get; set; }

		public int startRecharge { get; set; }

		public int vipMeasure { get; set; }

		public int rechargeAddPoint { get; set; }

		public int startRechargePrice { get; set; }

		public int numberMeasure { get; set; }

		public int priceAddPercent { get; set; }

		public int rechargeAmount { get; set; }

		public string GetKey()
		{
			return idx;
		}

		public int GetMaxRechargeCount(int currentVip)
		{
			return (currentVip - startVip) / vipMeasure * rechargeAddPoint + startRecharge;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
