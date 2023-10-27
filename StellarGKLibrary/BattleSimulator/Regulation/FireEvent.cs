using System;
using Newtonsoft.Json;

namespace BattleSimulator.DataTables.DataRowTable
{
	[JsonObject]
	[Serializable]
	public class FireEvent
	{
		public FireEvent(int _time, int _firePointTypeIndex, string _firePointBonePath)
		{
			time = _time;
			firePointTypeIndex = _firePointTypeIndex;
			firePointBonePath = _firePointBonePath;
		}

		public int time { get; private set; }

		public int firePointTypeIndex { get; private set; }

		public string firePointBonePath { get; private set; }
	}
}
