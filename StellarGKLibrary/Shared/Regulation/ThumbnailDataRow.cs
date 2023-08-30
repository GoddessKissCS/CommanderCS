using StellarGKLibrary.Enums;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class ThumbnailDataRow : DataRow
	{
		private ThumbnailDataRow()
		{
		}

		public int idx { get; set; }

		public ThumbnailType category { get; set; }

		public string c_idx { get; set; }

		public string resource { get; set; }

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
