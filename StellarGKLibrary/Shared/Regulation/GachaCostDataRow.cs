using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class GachaCostDataRow : DataRow
	{
		public string index { get; set; }

		public string type { get; set; }

		public int count { get; set; }

		public EGoods priceType { get; set; }

		public int cost { get; set; }

		public string GetKey()
		{
			return index;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
