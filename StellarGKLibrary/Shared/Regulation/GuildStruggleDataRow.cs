using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Numerics;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class GuildStruggleDataRow : DataRow
	{
		public string idx { get; set; }

		public int positionx { get; set; }

		public int positiony { get; set; }

		public int guildpoint { get; set; }

		public string battlemap { get; set; }

		public string enemymap { get; set; }

		public Vector3 position
		{
			get
			{
				return new Vector3((float)positionx, (float)positiony, 0f);
			}
		}

		public string GetKey()
		{
			return idx;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
		}
	}
}
