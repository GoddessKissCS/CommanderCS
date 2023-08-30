using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class UserLevelDataRow : DataRow
	{
		public int level { get; set; }

		public int exp { get; set; }

		public int uExp { get; set; }

		public int maxBullet { get; set; }

		public int maxSkill { get; set; }

		public int rewardBullet { get; set; }

		public int bankGold { get; set; }

		public float goldIncrease { get; set; }

		public string GetKey()
		{
			return level.ToString();
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
