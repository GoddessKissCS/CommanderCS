using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;
using StellarGKLibrary.Enum;

namespace BattleSimulator.DataTables.DataRowTable
{
    [Serializable]
	public class CommanderVoiceDataRow : DataRow
	{
		private CommanderVoiceDataRow()
		{
		}

		public string index { get; private set; }

		public ECommanderVoiceEventType type { get; private set; }

		[JsonProperty("voicesound")]
		public string sound { get; private set; }

		public string GetKey()
		{
			return string.Format("{0}_{1}", index, (int)type);
		}

	}
}
