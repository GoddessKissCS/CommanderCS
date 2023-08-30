using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class CommanderLevelDataRow : DataRow
	{
		public int level { get; set; }

		public int exp { get; set; }

		public int aexp { get; set; }

		public int AddLeadership { get; set; }

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
