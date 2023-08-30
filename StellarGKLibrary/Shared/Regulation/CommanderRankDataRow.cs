using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.Enums;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class CommanderRankDataRow : DataRow
	{
		public int rank { get; set; }

		public EGoods medalGoodsType { get; set; }

		public int medal { get; set; }

		public int gold { get; set; }

		public int completeCash { get; set; }

		public int time { get; set; }

		public string GetKey()
		{
			return rank.ToString();
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
