using StellarGKLibrary.Enums;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class WaveBattleDataRow : DataRow
	{
		public string idx { get; set; }

		public string name { get; set; }

		public string thumbnail { get; set; }

		public string explanation { get; set; }

		public int helper { get; set; }

		public int enemy { get; set; }

		public int endTurn { get; set; }

		public string battlemap { get; set; }

		public string enemymap { get; set; }

		public string bgm { get; set; }

		public List<int> enter { get; set; }

		public string GetKey()
		{
			return idx;
		}
	}
}
