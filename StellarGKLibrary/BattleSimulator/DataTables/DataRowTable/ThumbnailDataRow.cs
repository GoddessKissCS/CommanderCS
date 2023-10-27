using System;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class ThumbnailDataRow : DataRow
	{
		private ThumbnailDataRow()
		{
		}

		public int idx { get; private set; }

		public ThumbnailType category { get; private set; }

		public string c_idx { get; private set; }

		public string resource { get; private set; }

		public string GetKey()
		{
			return idx.ToString();
		}

		public string resourceName
		{
			get
			{
				return resource;
			}
		}
	}
}
