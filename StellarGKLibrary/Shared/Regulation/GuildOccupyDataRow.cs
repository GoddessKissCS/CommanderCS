using StellarGKLibrary.Enums;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class GuildOccupyDataRow : DataRow
	{
		public string idx { get; set; }

		public string s_idx { get; set; }

		public string symbol { get; set; }

		public int stageType { get; set; }

		public int positionx { get; set; }

		public int positiony { get; set; }

		public int crossRoads { get; set; }

		public List<int> next { get; set; }

		public List<int> nexttime { get; set; }

		public int oPoint { get; set; }

		public int rewardType { get; set; }

		public string rewardIdx { get; set; }

		public int rewardCount { get; set; }

		public string building { get; set; }

		public string GetKey()
		{
			return idx;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
