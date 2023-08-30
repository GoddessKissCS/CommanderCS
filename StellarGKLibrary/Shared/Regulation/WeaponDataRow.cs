using StellarGKLibrary.Enums;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class WeaponDataRow : DataRow
	{
		public string idx { get; set; }

		public string weaponName { get; set; }

		public int slotType { get; set; }

		public int weaponGrade { get; set; }

		public List<EItemStatType> statType { get; set; }

		public List<int> statBasePoint { get; set; }

		public List<int> statAddPoint { get; set; }

		public ESkillTargetType targetType { get; set; }

		public List<int> clingingTurn { get; set; }

		public List<string> statusEffectDrks { get; set; }

		public List<string> explanation { get; set; }

		public int privateWeapon { get; set; }

		public EWeaponSkill skillPoint { get; set; }

		public string unitIdx { get; set; }

		public string skillIdx { get; set; }

		public string decompositionReward { get; set; }

		public int value { get; set; }

		public List<int> materialMax { get; set; }

		public List<int> materialMin { get; set; }

		public int productionTime { get; set; }

		public string weaponIcon { get; set; }

		public string weaponDescription { get; set; }

		public string weaponSetType { get; set; }

		public string GetKey()
		{
			return idx;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}

		public static int GetStatPoint(int level, int basePoint, int addPoint)
		{
			return basePoint + level * addPoint;
		}

		public const int StatPointCount = 4;
	}
}
