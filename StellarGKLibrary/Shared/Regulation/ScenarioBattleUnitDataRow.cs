using StellarGKLibrary.Enums;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class ScenarioBattleUnitDataRow : DataRow
	{
		public string battleIdx { get; set; }

		public int uType { get; set; }

		public string unitId { get; set; }

		public int unitLevel { get; set; }

		public int unitPosition { get; set; }

		public int unitGrade { get; set; }

		public int unitClass { get; set; }

		public List<int> skillLevel { get; set; }

		public string GetKey()
		{
			return string.Format("{0}_{1}_{2}", battleIdx, unitId, unitPosition);
		}
	}
}
