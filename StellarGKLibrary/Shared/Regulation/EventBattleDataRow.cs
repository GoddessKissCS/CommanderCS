using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class EventBattleDataRow : DataRow
	{
		public string eventIdx { get; set; }

		public string goodsIdx { get; set; }

		public int goodsAmount { get; set; }

		public string eventImg { get; set; }

		public string eventLogo { get; set; }

		public ERewardType mainRewardType { get; set; }

		public string mainRewardIdx { get; set; }

		public int mainRewardAmount { get; set; }

		public string eventPointIdx { get; set; }

		public int gachaOneTimeAmount { get; set; }

		public string GetKey()
		{
			return eventIdx;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
