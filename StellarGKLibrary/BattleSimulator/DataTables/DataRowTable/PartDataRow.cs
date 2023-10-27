using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class PartDataRow : DataRow
	{
		public string type { get; private set; }

		public int grade { get; private set; }

		public string name { get; private set; }

		public EUnitType mark { get; private set; }

		public string serverFieldName { get; private set; }

		public int max { get; private set; }

		public string description { get; private set; }

		public string GetKey()
		{
			return type.ToString();
		}

		public string bgResource
		{
			get
			{
				return itemBGPrefix + grade;
			}
		}

		public string markResource
		{
			get
			{
				return itemMarkPrefix + (int)mark;
			}
		}

		public string gradeResource
		{
			get
			{
				return itemOutlinePrefix + grade;
			}
		}


		public static readonly string itemBGPrefix = "icon_bg";

		public static readonly string itemMarkPrefix = "icon_mark";

		public static readonly string itemOutlinePrefix = "icon_outline";
	}
}
