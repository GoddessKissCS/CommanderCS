using StellarGKLibrary.Enums;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class StrongestBuffBattleDataRow : DataRow
	{
		public string idx { get; set; }

		public EWorldDuelBuff buffTarget { get; set; }

		public int buffLevel { get; set; }

		public int buffType { get; set; }

		public int buffAdd { get; set; }

		public EWorldDuelBuffEffect buffEffectType { get; set; }

		public int upgradeCoin { get; set; }

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
