using StellarGKLibrary.Enums;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class ScenarioBattleDataRow : DataRow
	{
		public string battleIdx { get; set; }

		public string battlemap { get; set; }

		public string enemymap { get; set; }

		public int turn1 { get; set; }

		public int turn2 { get; set; }

		public int turn3 { get; set; }

		public string quarter { get; set; }

		public string GetKey()
		{
			return battleIdx;
		}
	}
}
