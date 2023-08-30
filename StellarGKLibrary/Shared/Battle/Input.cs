using Newtonsoft.Json;

namespace StellarGKLibrary.Shared.Battle
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Input
    {
        internal Input()
        {
        }

        public Input(int unitIndex, int skillIndex, int targetIndex)
        {
            this._unitIndex = unitIndex;
            this._skillIndex = skillIndex;
            this._targetIndex = targetIndex;
            this._result = false;
        }

        public int unitIndex
        {
            get
            {
                return this._unitIndex;
            }
        }

        public int skillIndex
        {
            get
            {
                return this._skillIndex;
            }
        }

        public int targetIndex
        {
            get
            {
                return this._targetIndex;
            }
        }

        public bool result
        {
            get
            {
                return this._result;
            }
        }

        public static Input Copy(Input src)
        {
            return new Input
            {
                _unitIndex = src._unitIndex,
                _skillIndex = src._skillIndex,
                _targetIndex = src._targetIndex,
                _result = src._result
            };
        }

        public static bool IsSame(Input f1, Input f2)
        {
            return f1 == f2 || (f1.unitIndex == f2.unitIndex && f1.skillIndex == f2.skillIndex && f1.targetIndex == f2.targetIndex && f1._result == f2._result);
        }

        [JsonProperty("uidx")]
        internal int _unitIndex;

        [JsonProperty("sidx")]
        internal int _skillIndex;

        [JsonProperty("tidx")]
        internal int _targetIndex;

        [JsonIgnore]
        internal bool _result;
    }
}
