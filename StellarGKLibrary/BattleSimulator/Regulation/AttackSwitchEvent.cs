using System;
using Newtonsoft.Json;

namespace BattleSimulator.DataTables.DataRowTable
{
	[JsonObject]
	[Serializable]
	public class AttackSwitchEvent
	{
		public AttackSwitchEvent(int _time, E_SWITCH_TYPE _etype)
		{
			time = _time;
			eType = _etype;
		}

		public int time { get; private set; }

		public E_SWITCH_TYPE eType;

		public enum E_SWITCH_TYPE
		{
			LOCAL,
			TARGET
		}
	}
}
