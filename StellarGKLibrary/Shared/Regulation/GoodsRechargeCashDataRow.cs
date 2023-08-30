using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class GoodsRechargeCashDataRow : DataRow
	{
		public int index { get; set; }

		public EGoods goods { get; set; }

		public int repeatCount { get; set; }

		public int cash { get; set; }

		public string GetKey()
		{
			return index.ToString();
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
