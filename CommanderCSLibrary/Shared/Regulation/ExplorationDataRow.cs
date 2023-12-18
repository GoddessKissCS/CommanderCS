using CommanderCSLibrary.Shared.Enum;

namespace CommanderCSLibrary.Shared.Regulation;

[Serializable]
public class ExplorationDataRow : DataRow
{
	public int idx { get; private set; }

	public string worldMap { get; private set; }

	public int minClass { get; private set; }

	public int searchTime { get; private set; }

	public int searchExp { get; private set; }

	public string worldMapDescription { get; private set; }

	public string GetKey()
	{
		return idx.ToString();
	}
}
