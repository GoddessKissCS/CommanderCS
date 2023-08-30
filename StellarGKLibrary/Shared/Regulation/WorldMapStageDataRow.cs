using StellarGKLibrary.Enums;
using Newtonsoft.Json;
using System.Numerics;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class WorldMapStageDataRow : DataRow
	{
		private WorldMapStageDataRow()
		{
		}

		public string id { get; set; }

		public string worldMapId { get; set; }

		public float positionX { get; set; }

		public float positionY { get; set; }

		public Vector3 position
		{
			get
			{
				return new Vector3(positionX, positionY, 0f);
			}
		}

		public string typeId { get; set; }

		public EStageTypeIdRange type
		{
			get
			{
				int num = 0;
				if (!int.TryParse(typeId, out num))
				{
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

		public int bullet { get; set; }

		public ETerrainType terrain { get; set; }

		public int order { get; set; }

		public string enemyId { get; set; }

		public int rewardGold { get; set; }

		public string title { get; set; }

		public string description { get; set; }

		public int favorup { get; set; }

		public string battlemap { get; set; }

		public string enemymap { get; set; }

		public int turn1 { get; set; }

		public int turn2 { get; set; }

		public int turn3 { get; set; }

		[JsonProperty("getStar01")]
		public EBattleClearCondition clearCondition1 { get; set; }

		[JsonProperty("getStar01Count")]
		public string clearCondition1_Value { get; set; }

		[JsonProperty("getStar02")]
		public EBattleClearCondition clearCondition2 { get; set; }

		[JsonProperty("getStar02Count")]
		public string clearCondition2_Value { get; set; }

		public int commanderexp { get; set; }

		public string GetKey()
		{
			return id;
		}

		[JsonObject]
		[Serializable]
		public class Range
		{
			public int min { get; set; }

			public int max { get; set; }
		}
	}
}
