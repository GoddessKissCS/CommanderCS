using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [Serializable]
	public class RaidChallengeDataRow : DataRow
	{
		private RaidChallengeDataRow()
		{
		}

		public string key { get; private set; }

		public string commanderId { get; private set; }

		public int commanderPos { get; private set; }

		public string battlemap { get; private set; }

		public string enemymap { get; private set; }

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
