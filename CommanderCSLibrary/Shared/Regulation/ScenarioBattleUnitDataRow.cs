using CommanderCSLibrary.Shared.Enum;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation;

[Serializable]
[JsonObject]
public class ScenarioBattleUnitDataRow : DataRow
{
	public string battleIdx { get; private set; }

	public int uType { get; private set; }

	public string unitId { get; private set; }

	public int unitLevel { get; private set; }

	public int unitPosition { get; private set; }

	public int unitGrade { get; private set; }

	public int unitClass { get; private set; }

	public List<int> skillLevel { get; private set; }

	public string GetKey()
	{
		return $"{battleIdx}_{unitId}_{unitPosition}";
	}
}
