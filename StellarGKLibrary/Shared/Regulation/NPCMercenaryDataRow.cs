using StellarGKLibrary.Enums;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class NPCMercenaryDataRow : DataRow
	{
		private NPCMercenaryDataRow()
		{
		}

		public string id { get; set; }

		public int wave { get; set; }

		public string unitId { get; set; }

		public int unitLevel { get; set; }

		public int unitGrade { get; set; }

		public int unitClass { get; set; }

		public List<int> skillLevel { get; set; }

		public int unitScale { get; set; }

		public string explanation { get; set; }

		public string GetKey()
		{
			return id.ToString();
		}
	}
}
