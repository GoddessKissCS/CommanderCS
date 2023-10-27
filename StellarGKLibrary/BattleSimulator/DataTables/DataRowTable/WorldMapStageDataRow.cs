using System;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;
using System.Numerics;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class WorldMapStageDataRow : DataRow
	{
		private WorldMapStageDataRow()
		{
		}

		public string id { get; private set; }

		public string worldMapId { get; private set; }

		public float positionX { get; private set; }

		public float positionY { get; private set; }

		public Vector3 position
		{
			get
			{
				return new Vector3(positionX, positionY, 0f);
			}
		}

		public string typeId { get; private set; }

		public EStageTypeIdRange type
		{
			get
			{
				int num = 0;
				if (!int.TryParse(typeId, out num))
				{
					Logger.Log("invalid state");
					return EStageTypeIdRange.Undefined;
				}
				if (1 <= num && 100 >= num)
				{
					return EStageTypeIdRange.GuardPost;
				}
				if (101 <= num && 200 >= num)
				{
					return EStageTypeIdRange.Storage;
				}
				if (201 <= num && 300 >= num)
				{
					return EStageTypeIdRange.Factory;
				}
				if (301 <= num && 400 >= num)
				{
					return EStageTypeIdRange.Terrorist;
				}
				if (401 <= num && 500 >= num)
				{
					return EStageTypeIdRange.PowerPlant;
				}
				return EStageTypeIdRange.Undefined;
			}
		}

		public int bullet { get; private set; }

		public ETerrainType terrain { get; private set; }

		public int order { get; private set; }

		public string enemyId { get; private set; }

		public int rewardGold { get; private set; }

		public string title { get; private set; }

		public string description { get; private set; }

		public int favorup { get; private set; }

		public string battlemap { get; private set; }

		public string enemymap { get; private set; }

		public int turn1 { get; private set; }

		public int turn2 { get; private set; }

		public int turn3 { get; private set; }

		[JsonProperty("getStar01")]
		public EBattleClearCondition clearCondition1 { get; private set; }

		[JsonProperty("getStar01Count")]
		public string clearCondition1_Value { get; private set; }

		[JsonProperty("getStar02")]
		public EBattleClearCondition clearCondition2 { get; private set; }

		[JsonProperty("getStar02Count")]
		public string clearCondition2_Value { get; private set; }

		public int commanderexp { get; private set; }

		public string GetKey()
		{
			return id;
		}

		[JsonObject]
		[Serializable]
		public class Range
		{
			public int min { get; private set; }

			public int max { get; private set; }
		}
	}
}
