using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StellarGKLibrary.DataTables;

namespace BattleSimulator.DataTables.DataRowTable
{
    [JsonObject]
	[Serializable]
	public class GroupMemberDataRow : DataRow
	{
		private GroupMemberDataRow()
		{
		}

		public string gidx { get; private set; }

		public string idx { get; private set; }

		public int memberType { get; private set; }

		public int grade { get; private set; }

		public string memberIdx { get; private set; }

		public string GetKey()
		{
			return gidx;
		}

	}
}
