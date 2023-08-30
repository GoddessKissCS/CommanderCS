using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class PartDataRow : DataRow
	{
		public string type { get; set; }

		public int grade { get; set; }

		public string name { get; set; }

		public EUnitType mark { get; set; }

		public string serverFieldName { get; set; }

		public int max { get; set; }

		public string description { get; set; }

		public string GetKey()
		{
			return type.ToString();
		}

		public string bgResource
		{
			get
			{
				return PartDataRow.itemBGPrefix + grade;
			}
		}

		public string markResource
		{
			get
			{
				return PartDataRow.itemMarkPrefix + (int)mark;
			}
		}

		public string gradeResource
		{
			get
			{
				return PartDataRow.itemOutlinePrefix + grade;
			}
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}

		public static readonly string itemBGPrefix = "icon_bg";

		public static readonly string itemMarkPrefix = "icon_mark";

		public static readonly string itemOutlinePrefix = "icon_outline";
	}
}
