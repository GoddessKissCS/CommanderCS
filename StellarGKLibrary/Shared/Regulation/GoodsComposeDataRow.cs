using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class GoodsComposeDataRow : DataRow
	{
		public string idx { get; set; }

		public string composeIdx { get; set; }

		public int value { get; set; }

		public string rewardIdx { get; set; }

		public int rewardValue { get; set; }

		public string GetKey()
		{
			return composeIdx;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
