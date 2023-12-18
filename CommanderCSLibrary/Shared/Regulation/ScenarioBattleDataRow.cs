using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation;

[Serializable]
[JsonObject]
public class ScenarioBattleDataRow : DataRow
{
	public string battleIdx { get; private set; }

	public string battlemap { get; private set; }

	public string enemymap { get; private set; }

	public int turn1 { get; private set; }

	public int turn2 { get; private set; }

	public int turn3 { get; private set; }

	public string quarter { get; private set; }

	public string GetKey()
	{
		return battleIdx;
	}
}
