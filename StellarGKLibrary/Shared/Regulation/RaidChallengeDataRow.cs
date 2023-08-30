using StellarGKLibrary.Enums;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[Serializable]
	public class RaidChallengeDataRow : DataRow
	{
		private RaidChallengeDataRow()
		{
		}

		public string key { get; set; }

		public string commanderId { get; set; }

		public int commanderPos { get; set; }

		public string battlemap { get; set; }

		public string enemymap { get; set; }

		[JsonIgnore]
		public IList<string> parts
		{
			get
			{
				return _parts.AsReadOnly();
			}
		}

		[JsonIgnore]
		public IList<int> partsPosition
		{
			get
			{
				return _partsPosition.AsReadOnly();
			}
		}

		public string GetKey()
		{
			return key;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			Regulation.FillList<string>(ref _parts, 9);
			Regulation.FillList<int>(ref _partsPosition, 9);
		}

		public const int PartsCount = 9;

		[JsonProperty("parts")]
		private List<string> _parts;

		[JsonProperty("partsPos")]
		private List<int> _partsPosition;
	}
}
