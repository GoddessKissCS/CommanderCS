using CommanderCSLibrary.Shared.Enum;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation;

[Serializable]
[JsonObject]
public class EventBattleFieldDataRow : DataRow
{
	public int eventIdx { get; private set; }

	public int idx { get; private set; }

	public string name { get; private set; }

	public string thumbnail { get; private set; }

	public string explanation { get; private set; }

	public EJob job { get; private set; }

	public int weWave { get; private set; }

	public int helper { get; private set; }

	public string enemy { get; private set; }

	public int endTurn { get; private set; }

	public string battleMap { get; private set; }

	public string enemyMap { get; private set; }

	public string bgm { get; private set; }

	public int bullet { get; private set; }

	[JsonProperty("getStar01")]
	public EBattleClearCondition clearCondition1 { get; private set; }

	[JsonProperty("getStar01Count")]
	public string clearCondition1_Value { get; private set; }

	[JsonProperty("getStar02")]
	public EBattleClearCondition clearCondition2 { get; private set; }

	[JsonProperty("getStar02Count")]
	public string clearCondition2_Value { get; private set; }

	public string GetKey()
	{
		return $"{eventIdx}_{idx}";
	}

	[OnDeserialized]
	private void OnDeserialized(StreamingContext context)
	{
	}
}
