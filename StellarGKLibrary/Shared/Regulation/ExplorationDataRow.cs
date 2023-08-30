using StellarGKLibrary.Enums;

namespace StellarGKLibrary.Shared.Regulation
{
	[Serializable]
	public class ExplorationDataRow : DataRow
	{
		public int idx { get; set; }

		public string worldMap { get; set; }

		public int minClass { get; set; }

		public int searchTime { get; set; }

		public int searchExp { get; set; }

		public string worldMapDescription { get; set; }

		public string GetKey()
		{
			return idx.ToString();
		}
	}
}
