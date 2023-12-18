using CommanderCSLibrary.Shared.Enum;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CommanderCSLibrary.Shared.Regulation;

[Serializable]
[JsonObject]
public class InAppProductDataRow : DataRow
{
	public int iapidx { get; private set; }

	public string googlePlayID { get; private set; }

	public int sort { get; private set; }

	public int cash { get; private set; }

	public string wonPrice { get; private set; }

	public string dollarPrice { get; private set; }

	public ECashRechargeType type { get; private set; }

	public string stringidx { get; private set; }

	public string explanation { get; private set; }

	public string stringidxEvent { get; private set; }

	public string explanationEvent { get; private set; }

	public string explanationFirst { get; private set; }

	public string icon { get; private set; }

	public int isSell { get; private set; }

	public int uiType { get; private set; }

	public int count { get; private set; }

	public int availableLevel { get; private set; }

	public string GetKey()
	{
		return googlePlayID;
	}

	[OnDeserialized]
	private void OnDeserialized(StreamingContext context)
	{
	}
}
