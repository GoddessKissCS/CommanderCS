using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class GroupInfoDataRow : DataRow
	{
		private GroupInfoDataRow()
		{
		}

		public string tabidx { get; set; }

		public string tabname { get; set; }

		public string groupIdx { get; set; }

		public string groupName { get; set; }

		public string groupComment { get; set; }

		public int typeIndex { get; set; }

		public ERewardType rewardType { get; set; }

		public int rewardIdx { get; set; }

		public int minCount { get; set; }

		public string GetKey()
		{
			return groupIdx;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
