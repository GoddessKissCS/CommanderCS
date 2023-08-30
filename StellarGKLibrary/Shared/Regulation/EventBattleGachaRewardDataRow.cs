using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class EventBattleGachaRewardDataRow : DataRow
	{
		public int eventIdx { get; set; }

		public int count { get; set; }

		public int idx { get; set; }

		public int mainReward { get; set; }

		public ERewardType rewardType { get; set; }

		public string rewardIdx { get; set; }

		public int rewardAmount { get; set; }

		public int rewardCount { get; set; }

		public int effect { get; set; }

		public string GetKey()
		{
			return string.Format("{0}_{1}_{2}", eventIdx, count, idx);
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
