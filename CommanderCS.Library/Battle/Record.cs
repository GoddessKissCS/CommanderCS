using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Library.Battle
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Record
    {
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

        public int simulatorVersion => _simulatorVersion;

        public double regulationVersion => _regulationVersion;

        public Option option => _option;

        public InitState initState => _initState;

        public int length => _length;

        public IList<Frame> frames => _frames.AsReadOnly();

        public Result result => _result;

        internal Record()
        {
        }

        public bool HasLhsInput(int frameNum)
        {
            return _lhsInputMap.ContainsKey(frameNum);
        }

        public Input GetLhsInput(int frameNum)
        {
            return _lhsInputMap[frameNum];
        }

        public bool HasRhsInput(int frameNum)
        {
            return _rhsInputMap.ContainsKey(frameNum);
        }

        public Input GetRhsInput(int frameNum)
        {
            return _rhsInputMap[frameNum];
        }

        public static Record Copy(Record src)
        {
            Record record = new()
            {
                _simulatorVersion = src._simulatorVersion,
                _regulationVersion = src._regulationVersion,
                _option = src._option,
                _initState = InitState.Copy(src._initState),
                _lhsInputMap = [],
                _rhsInputMap = [],
                _frames = [],
                _length = src._length,
                _result = null,
            };
            foreach (KeyValuePair<int, Input> item in src._lhsInputMap)
            {
                record._lhsInputMap.Add(item.Key, Input.Copy(item.Value));
            }
            foreach (KeyValuePair<int, Input> item2 in src._rhsInputMap)
            {
                record._rhsInputMap.Add(item2.Key, Input.Copy(item2.Value));
            }
            return record;
        }

        public static explicit operator JToken(Record value)
        {
            JArray jArray =
            [
                value._simulatorVersion,
                value._regulationVersion,
                (JToken)value._option,
                (JToken)value._initState,
                value._length,
            ];
            if (value._lhsInputMap.Count > 0)
            {
                JArray jArray2 = [];
                Dictionary<int, Input>.Enumerator enumerator = value._lhsInputMap.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    JArray jArray3 =
                    [
                        enumerator.Current.Key,
                        enumerator.Current.Value._unitIndex,
                        enumerator.Current.Value._skillIndex,
                        enumerator.Current.Value._targetIndex,
                    ];
                    jArray2.Add(jArray3);
                }
                jArray.Add(jArray2);
            }
            else
            {
                jArray.Add(string.Empty);
            }
            if (value._rhsInputMap.Count > 0)
            {
                JArray jArray4 = [];
                Dictionary<int, Input>.Enumerator enumerator2 = value._rhsInputMap.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                    JArray jArray5 =
                    [
                        enumerator2.Current.Key,
                        enumerator2.Current.Value._unitIndex,
                        enumerator2.Current.Value._skillIndex,
                        enumerator2.Current.Value._targetIndex,
                    ];
                    jArray4.Add(jArray5);
                }
                jArray.Add(jArray4);
            }
            else
            {
                jArray.Add(string.Empty);
            }
            return jArray;
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
                _lhsInputMap = []
            };
            if (value[5].Type == JTokenType.Array)
            {
                JArray jArray = (JArray)value[5];
                for (int i = 0; i < jArray.Count; i++)
                {
                    JArray jArray2 = (JArray)jArray[i];
                    record._lhsInputMap.Add((int)jArray2[0], new Input((int)jArray2[1], (int)jArray2[2], (int)jArray2[3]));
                }
            }
            record._rhsInputMap = [];
            if (value[6].Type == JTokenType.Array)
            {
                JArray jArray3 = (JArray)value[6];
                for (int j = 0; j < jArray3.Count; j++)
                {
                    JArray jArray4 = (JArray)jArray3[j];
                    record._rhsInputMap.Add((int)jArray4[0], new Input((int)jArray4[1], (int)jArray4[2], (int)jArray4[3]));
                }
            }
            return record;
        }
    }
}