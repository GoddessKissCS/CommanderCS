using StellarGKLibrary.Enums;
using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Regulation
{
	[JsonObject]
	[Serializable]
	public class AttackSwitchEvent
	{
		public AttackSwitchEvent(int time, AttackSwitchEvent.E_SWITCH_TYPE etype)
		{
			time = time;
			eType = etype;
		}

		public int time { get; set; }

		public AttackSwitchEvent.E_SWITCH_TYPE eType;

		public enum E_SWITCH_TYPE
		{
			LOCAL,
			TARGET
		}
	}
}
