using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class AnnihilateBattleDataRow : DataRow
	{
		private AnnihilateBattleDataRow()
		{
		}

		public string idx { get; private set; }

		public int positionX { get; private set; }

		public int positionY { get; private set; }

		public int enemyLevelGap { get; private set; }

		public int enemyGrade { get; private set; }

		public int enemyClass { get; private set; }

		public int enemyCostume { get; private set; }

		public int enemyfavorRewardStep { get; private set; }

		public int enemyMarry { get; private set; }

		public int enemySkill { get; private set; }

		public int needSpeed { get; private set; }

		public string reward { get; private set; }

		public string battleMap { get; private set; }

		public string enemyMap { get; private set; }

		public int sp { get; private set; }

		public string bmg { get; private set; }

		public int scale { get; private set; }

		public int endTurn { get; private set; }

		public int battleWave { get; private set; }

		public string GetKey()
		{
			return idx;
		}

	}
}
