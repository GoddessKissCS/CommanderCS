using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class GuildSkillDataRow : DataRow
	{
		public int idx { get; set; }

		public int skilllevel { get; set; }

		public int value { get; set; }

		public int level { get; set; }

		public int cost { get; set; }

		public string name { get; set; }

		public string description { get; set; }

		public string GetKey()
		{
			return string.Format("{0}_{1}", idx, skilllevel);
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
