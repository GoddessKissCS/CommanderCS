using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BattleSimulator.Battle
{
	[JsonObject(MemberSerialization.OptIn)]
	public class WaveBattleData
	{
		public static WaveBattleData Create(string id, int wave, int wvtn, List<int> ltnLine = null)
		{
            WaveBattleData waveBattleData = new()
            {
                _id = id,
                _wave = wave,
                _waveTurn = wvtn,
                _lhsTurnLine = ltnLine,
                _lhsWaitingInput = false,
                _lhsTurnUnitIndex = -1
            };
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
			return new()
            {
				_id = src._id,
				_wave = src._wave,
				_waveTurn = src._waveTurn,
				_lhsTurnLine = src._lhsTurnLine,
				_lhsWaitingInput = src._lhsWaitingInput,
				_lhsTurnUnitIndex = src._lhsTurnUnitIndex
			};
		}

		public static explicit operator JToken(WaveBattleData value)
		{
			if (value == null)
			{
				return string.Empty;
			}
            JArray jarray = new()
            {
                value._id,
                value._wave,
                value._waveTurn
            };
            if (value._lhsTurnLine != null)
			{
				JArray jarray2 = new();
				for (int i = 0; i < value._lhsTurnLine.Count; i++)
				{
					jarray2.Add(value._lhsTurnLine[i]);
				}
				jarray.Add(jarray2);
			}
			else
			{
				jarray.Add(string.Empty);
			}
			return jarray;
		}

		public static explicit operator WaveBattleData(JToken value)
		{
			if (value.Type != JTokenType.Array)
			{
				return null;
			}
            WaveBattleData waveBattleData = new()
            {
                _id = (string)value[0],
                _wave = (int)value[1],
                _waveTurn = (int)value[2],
                _lhsTurnLine = new List<int>()
            };
            if (value[3].Type == JTokenType.Array)
			{
				JArray jarray = (JArray)value[3];
				for (int i = 0; i < jarray.Count; i++)
				{
					waveBattleData._lhsTurnLine.Add((int)jarray[i]);
				}
			}
			return waveBattleData;
		}

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
	}
}
