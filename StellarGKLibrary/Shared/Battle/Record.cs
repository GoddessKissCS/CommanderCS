using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StellarGKLibrary.Shared.Battle
{
	[JsonObject(MemberSerialization.OptIn)]
	public class Record
	{
		internal Record()
		{
		}

		public int simulatorVersion
		{
			get
			{
				return this._simulatorVersion;
			}
		}
		public double regulationVersion
		{
			get
			{
				return this._regulationVersion;
			}
		}
		public Option option
		{
			get
			{
				return this._option;
			}
		}
		public InitState initState
		{
			get
			{
				return this._initState;
			}
		}
		public int length
		{
			get
			{
				return this._length;
			}
		}
		public IList<Frame> frames
		{
			get
			{
				return this._frames.AsReadOnly();
			}
		}
		public Result result
		{
			get
			{
				return this._result;
			}
		}
		public bool HasLhsInput(int frameNum)
		{
			return this._lhsInputMap.ContainsKey(frameNum);
		}
		public Input GetLhsInput(int frameNum)
		{
			return this._lhsInputMap[frameNum];
		}
		public bool HasRhsInput(int frameNum)
		{
			return this._rhsInputMap.ContainsKey(frameNum);
		}
		public Input GetRhsInput(int frameNum)
		{
			return this._rhsInputMap[frameNum];
		}
		public static Record Copy(Record src)
		{
			Record record = new Record();
			record._simulatorVersion = src._simulatorVersion;
			record._regulationVersion = src._regulationVersion;
			record._option = src._option;
			record._initState = InitState.Copy(src._initState);
			record._lhsInputMap = new Dictionary<int, Input>();
			foreach (KeyValuePair<int, Input> keyValuePair in src._lhsInputMap)
			{
				record._lhsInputMap.Add(keyValuePair.Key, Input.Copy(keyValuePair.Value));
			}
			record._rhsInputMap = new Dictionary<int, Input>();
			foreach (KeyValuePair<int, Input> keyValuePair2 in src._rhsInputMap)
			{
				record._rhsInputMap.Add(keyValuePair2.Key, Input.Copy(keyValuePair2.Value));
			}
			record._frames = new List<Frame>();
			record._length = src._length;
			record._result = null;
			return record;
		}

		public static explicit operator JToken(Record value)
		{
            JArray jarray = new()
            {
                value._simulatorVersion,
                value._regulationVersion,
                (JToken)value._option,
                (JToken)value._initState,
                value._length
            };
            if (value._lhsInputMap.Count > 0)
			{
				JArray jarray2 = new JArray();
				Dictionary<int, Input>.Enumerator enumerator = value._lhsInputMap.GetEnumerator();
				while (enumerator.MoveNext())
				{
					JArray jarray3 = new JArray();
					JArray jarray4 = jarray3;
					KeyValuePair<int, Input> keyValuePair = enumerator.Current;
					jarray4.Add(keyValuePair.Key);
					JArray jarray5 = jarray3;
					KeyValuePair<int, Input> keyValuePair2 = enumerator.Current;
					jarray5.Add(keyValuePair2.Value._unitIndex);
					JArray jarray6 = jarray3;
					KeyValuePair<int, Input> keyValuePair3 = enumerator.Current;
					jarray6.Add(keyValuePair3.Value._skillIndex);
					JArray jarray7 = jarray3;
					KeyValuePair<int, Input> keyValuePair4 = enumerator.Current;
					jarray7.Add(keyValuePair4.Value._targetIndex);
					jarray2.Add(jarray3);
				}
				jarray.Add(jarray2);
			}
			else
			{
				jarray.Add(string.Empty);
			}
			if (value._rhsInputMap.Count > 0)
			{
				JArray jarray8 = new JArray();
				Dictionary<int, Input>.Enumerator enumerator2 = value._rhsInputMap.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					JArray jarray9 = new JArray();
					JArray jarray10 = jarray9;
					KeyValuePair<int, Input> keyValuePair5 = enumerator2.Current;
					jarray10.Add(keyValuePair5.Key);
					JArray jarray11 = jarray9;
					KeyValuePair<int, Input> keyValuePair6 = enumerator2.Current;
					jarray11.Add(keyValuePair6.Value._unitIndex);
					JArray jarray12 = jarray9;
					KeyValuePair<int, Input> keyValuePair7 = enumerator2.Current;
					jarray12.Add(keyValuePair7.Value._skillIndex);
					JArray jarray13 = jarray9;
					KeyValuePair<int, Input> keyValuePair8 = enumerator2.Current;
					jarray13.Add(keyValuePair8.Value._targetIndex);
					jarray8.Add(jarray9);
				}
				jarray.Add(jarray8);
			}
			else
			{
				jarray.Add(string.Empty);
			}
			return jarray;
		}

		public static explicit operator Record(JToken value)
		{
            Record record = new()
            {
                _simulatorVersion = (int)value[0],
                _regulationVersion = (double)value[1],
                _option = (Option)value[2],
                _initState = (InitState)value[3],
                _length = (int)value[4],
                _lhsInputMap = new Dictionary<int, Input>()
            };
            if (value[5].Type == JTokenType.Array)
			{
				JArray jarray = (JArray)value[5];
				for (int i = 0; i < jarray.Count; i++)
				{
					JArray jarray2 = (JArray)jarray[i];
					record._lhsInputMap.Add((int)jarray2[0], new Input((int)jarray2[1], (int)jarray2[2], (int)jarray2[3]));
				}
			}
			record._rhsInputMap = new Dictionary<int, Input>();
			if (value[6].Type == JTokenType.Array)
			{
				JArray jarray3 = (JArray)value[6];
				for (int j = 0; j < jarray3.Count; j++)
				{
					JArray jarray4 = (JArray)jarray3[j];
					record._rhsInputMap.Add((int)jarray4[0], new Input((int)jarray4[1], (int)jarray4[2], (int)jarray4[3]));
				}
			}
			return record;
		}


		[JsonProperty("smvr")]
		internal int _simulatorVersion;

		[JsonProperty("rgvr")]
		internal double _regulationVersion;

		[JsonProperty("optn")]
		internal Option _option;

		[JsonProperty("init")]
		internal InitState _initState;

		[JsonProperty("flen")]
		internal int _length;

		[JsonProperty("lipt")]
		internal Dictionary<int, Input> _lhsInputMap;

		[JsonProperty("ript")]
		internal Dictionary<int, Input> _rhsInputMap;

		[JsonIgnore]
		internal List<Frame> _frames;

		[JsonIgnore]
		internal Result _result;
	}
}
