using StellarGKLibrary.Enums;
using StellarGKLibrary.Enums;
using System.Collections.Generic;

namespace StellarGKLibrary.Shared.Regulation
{
	[Serializable]
	public class CooperateBattleDataRow : DataRow
	{
		public string idx { get; set; }

		public int step { get; set; }

		public ECooperateBattleEnemyType enemyType { get; set; }

		public string enemy { get; set; }

		public int enemyLevel { get; set; }

		public int enemyClass { get; set; }

		public int power { get; set; }

		public int endTurn { get; set; }

		public int goalPoint { get; set; }

		public int goalPointIncrease { get; set; }

		public string name { get; set; }

		public string description { get; set; }

		public string battleMap { get; set; }

		public string enemyMap { get; set; }

		public string bgm { get; set; }

		public int enemyrPos { get; set; }

		public List<string> parts { get; set; }

		public List<int> partsPos { get; set; }

		public string GetKey()
		{
			return idx;
		}
	}
}
