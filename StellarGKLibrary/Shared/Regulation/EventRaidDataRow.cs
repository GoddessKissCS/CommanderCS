using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class EventRaidDataRow : DataRow
	{
		public string idx { get; set; }

		public string eventIdx { get; set; }

		public string raidIdx { get; set; }

		public int endTurn { get; set; }

		public string battleMap { get; set; }

		public string enemyMap { get; set; }

		public string GetKey()
		{
			return string.Format("{0}_{1}", eventIdx, raidIdx);
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
