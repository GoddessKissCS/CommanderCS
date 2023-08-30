using StellarGKLibrary.Enums;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class EnemyCommanderDataRow : DataRow
	{
		private EnemyCommanderDataRow()
		{
		}

		public int index { get; set; }

		public string id { get; set; }

		public int wave { get; set; }

		public string commanderId { get; set; }

		public int commanderRank { get; set; }

		public string name { get; set; }

		public int power { get; set; }

		public string GetKey()
		{
			return id;
		}
	}
}
