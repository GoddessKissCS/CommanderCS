using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class RandomBoxRewardDataRow : DataRow
	{
		private RandomBoxRewardDataRow()
		{
		}

		public string idx { get; set; }

		public ERewardType rewardType { get; set; }

		public string rewardIdx { get; set; }

		public int rewardAmountMin { get; set; }

		public int rewardAmountMax { get; set; }

		public int giveType { get; set; }

		public string GetKey()
		{
			return string.Format("{0}_{1}_{2}", idx, rewardType, rewardIdx);
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
