using CommanderCSLibrary.Shared.Enum;
using CommanderCSLibrary.Shared.Enum;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation;

[Obsolete("deleted")]
[JsonObject]
public class AreaDataRow : DataRow
{
	public string id { get; private set; }

	public ETerrainType terrainType { get; private set; }

	public bool hasSeaControl { get; private set; }

	public int gridX { get; private set; }

	public int gridY { get; private set; }

	public float offsetX { get; private set; }

	public float offsetY { get; private set; }

	public int gold { get; private set; }

	public int gas { get; private set; }

	public string iconName
	{
		get
		{
			if (terrainType == ETerrainType.Base)
			{
				return "Base";
			}
			if (terrainType == ETerrainType.Sea)
			{
				return "Sea";
			}
			int num = Math.Max(gold, gas);
			if (num == gold)
			{
				return "Gold";
			}
			if (num == gas)
			{
				return "Gas";
			}
			return string.Empty;
		}
	}

	public string GetKey()
	{
		return id;
	}
}
