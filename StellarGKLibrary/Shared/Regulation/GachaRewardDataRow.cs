using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class GachaRewardDataRow : DataRow
	{
		public string gachaType { get; set; }

		public ERewardType rewardType { get; set; }

		public string rewardId { get; set; }

		public int rewardCount { get; set; }

		public int effectType { get; set; }

		public string GetKey()
		{
			return gachaType;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
