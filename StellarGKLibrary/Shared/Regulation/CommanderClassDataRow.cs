using StellarGKLibrary.Enums;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class CommanderClassDataRow : DataRow
	{
		public int index { get; set; }

		public int cls { get; set; }

		public int level { get; set; }

		public int limitedCmdLevel
		{
			get
			{
				return level;
			}
		}

		public int gold { get; set; }

		public Dictionary<string, int> pidx { get; set; }

		public Dictionary<string, int> pvalue { get; set; }

		public string GetKey()
		{
			return index.ToString();
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
