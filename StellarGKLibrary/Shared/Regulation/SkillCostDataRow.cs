using StellarGKLibrary.Enums;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class SkillCostDataRow : DataRow
	{
		public int level { get; set; }

		public string GetKey()
		{
			return level.ToString();
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}

		public List<int> typeCost;

		public List<int> typeLimitLevel;
	}
}
