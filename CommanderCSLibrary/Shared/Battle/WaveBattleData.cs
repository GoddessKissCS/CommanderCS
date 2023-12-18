using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCSLibrary.Shared.Battle;

[JsonObject(MemberSerialization.OptIn)]
public class WaveBattleData
{
	[JsonProperty("id")]
	internal string _id;

	[JsonProperty("stwv")]
	internal int _wave;

	[JsonProperty("wvtn")]
	internal int _waveTurn;

	[JsonProperty("ltnln")]
	internal List<int> _lhsTurnLine;

	[JsonProperty("ltnWipt")]
	internal bool _lhsWaitingInput;

	[JsonProperty("ltnUidx")]
	internal int _lhsTurnUnitIndex;

	public static WaveBattleData Create(string id, int wave, int wvtn, List<int> ltnLine = null)
	{
		WaveBattleData waveBattleData = new WaveBattleData();
		waveBattleData._id = id;
		waveBattleData._wave = wave;
		waveBattleData._waveTurn = wvtn;
		waveBattleData._lhsTurnLine = ltnLine;
		waveBattleData._lhsWaitingInput = false;
		waveBattleData._lhsTurnUnitIndex = -1;
		if (waveBattleData._lhsTurnLine == null)
		{
			waveBattleData._lhsTurnLine = new List<int>();
		}
		return waveBattleData;
	}

	public static WaveBattleData Copy(WaveBattleData src)
	{
		if (src == null)
		{
			return null;
		}
		WaveBattleData waveBattleData = new WaveBattleData();
		waveBattleData._id = src._id;
		waveBattleData._wave = src._wave;
		waveBattleData._waveTurn = src._waveTurn;
		waveBattleData._lhsTurnLine = src._lhsTurnLine;
		waveBattleData._lhsWaitingInput = src._lhsWaitingInput;
		waveBattleData._lhsTurnUnitIndex = src._lhsTurnUnitIndex;
		return waveBattleData;
	}

	public static explicit operator JToken(WaveBattleData value)
	{
		if (value == null)
		{
			return string.Empty;
		}
		JArray jArray = new JArray();
		jArray.Add(value._id);
		jArray.Add(value._wave);
		jArray.Add(value._waveTurn);
		if (value._lhsTurnLine != null)
		{
			JArray jArray2 = new JArray();
			for (int i = 0; i < value._lhsTurnLine.Count; i++)
			{
				jArray2.Add(value._lhsTurnLine[i]);
			}
			jArray.Add(jArray2);
		}
		else
		{
			jArray.Add(string.Empty);
		}
		return jArray;
	}

	public static explicit operator WaveBattleData(JToken value)
	{
		if (value.Type != JTokenType.Array)
		{
			return null;
		}
		WaveBattleData waveBattleData = new WaveBattleData();
		waveBattleData._id = (string)value[0];
		waveBattleData._wave = (int)value[1];
		waveBattleData._waveTurn = (int)value[2];
		waveBattleData._lhsTurnLine = new List<int>();
		if (value[3].Type == JTokenType.Array)
		{
			JArray jArray = (JArray)value[3];
			for (int i = 0; i < jArray.Count; i++)
			{
				waveBattleData._lhsTurnLine.Add((int)jArray[i]);
			}
		}
		return waveBattleData;
	}
}
