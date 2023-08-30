using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class RankingRewardDataRow : DataRow
	{
		public int r_idx { get; set; }

		public ERankingContentsType type { get; set; }

		public string g_idx { get; set; }

		public int rewardAmount { get; set; }

		public ERankingType rankingMinType { get; set; }

		public int rankingMin { get; set; }

		public ERankingType rankingMaxType { get; set; }

		public int rankingMax { get; set; }

		public string icon { get; set; }

		public string name { get; set; }

		public string GetKey()
		{
			return r_idx.ToString();
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
