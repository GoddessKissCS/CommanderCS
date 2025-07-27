using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommanderCS.Library.Battle
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Result
    {
        [JsonProperty("cksm")]
        internal string _checksum;

        [JsonProperty("tmot")]
        internal bool _isTimeOut;

        [JsonProperty("wsid")]
        internal int _winSide;

        [JsonProperty("gld")]
        internal int _gold;

        [JsonProperty("rnk")]
        internal int _clearRank;

        [JsonProperty("amkn")]
        internal int _armyDestoryCnt;

        [JsonProperty("amckn")]
        internal int _armyCmdDestoryCnt;

        [JsonProperty("nvkn")]
        internal int _navyDestoryCnt;

        [JsonProperty("nvckn")]
        internal int _navyCmdDestoryCnt;

        [JsonProperty("tadm")]
        internal long _totalAttackDamage;

        [JsonProperty("ltrp")]
        internal List<Troop> _lhsTroops;

        [JsonProperty("rtrp")]
        internal List<Troop> _rhsTroops;

        public string checksum => _checksum;

        public bool isTimeOut => _isTimeOut;

        public int winSide => _winSide;

        public int clearRank => _clearRank;

        public int gold => _gold;

        public int armyDestoryCnt => _armyDestoryCnt;

        public int armyCmdDestoryCnt => _armyCmdDestoryCnt;

        public int navyDestoryCnt => _navyDestoryCnt;

        public int navyCmdDestoryCnt => _navyCmdDestoryCnt;

        public long totalAttackDamage => _totalAttackDamage;

        public IList<Troop> lhsTroops => _lhsTroops.AsReadOnly();

        public IList<Troop> rhsTroops => _rhsTroops.AsReadOnly();

        public Troop victoryTroop
        {
            get
            {
                if (_winSide < 0)
                {
                    foreach (Troop lhsTroop in _lhsTroops)
                    {
                        if (!lhsTroop.isAnnihilated)
                        {
                            return lhsTroop;
                        }
                    }
                }
                if (_winSide > 0)
                {
                    foreach (Troop rhsTroop in _rhsTroops)
                    {
                        if (!rhsTroop.isAnnihilated)
                        {
                            return rhsTroop;
                        }
                    }
                }
                return null;
            }
        }

        public bool isLhsAnnihilated
        {
            get
            {
                foreach (Troop lhsTroop in _lhsTroops)
                {
                    if (lhsTroop.isAnnihilated)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public bool isRhsAnnihilated
        {
            get
            {
                foreach (Troop rhsTroop in _rhsTroops)
                {
                    if (rhsTroop.isAnnihilated)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public bool IsWin => _winSide < 0;

        internal Result()
        {
        }

        public static explicit operator JToken(Result value)
        {
            JArray jArray =
            [
                value._checksum,
                value._isTimeOut,
                value._winSide,
                value._gold,
                value._clearRank,
                value._armyDestoryCnt,
                value._armyCmdDestoryCnt,
                value._navyDestoryCnt,
                value._navyCmdDestoryCnt,
                value._totalAttackDamage,
            ];
            JArray jArray2 = [];
            for (int i = 0; i < value._lhsTroops.Count; i++)
            {
                jArray2.Add((JToken)value._lhsTroops[i]);
            }
            jArray.Add(jArray2);
            JArray jArray3 = [];
            for (int j = 0; j < value._rhsTroops.Count; j++)
            {
                jArray3.Add((JToken)value._rhsTroops[j]);
            }
            jArray.Add(jArray3);
            return jArray;
        }

        public static explicit operator Result(JToken value)
        {
            Result result = new()
            {
                _checksum = (string)value[0],
                _isTimeOut = (bool)value[1],
                _winSide = (int)value[2],
                _gold = (int)value[3],
                _clearRank = (int)value[4],
                _armyDestoryCnt = (int)value[5],
                _armyCmdDestoryCnt = (int)value[6],
                _navyDestoryCnt = (int)value[7],
                _navyCmdDestoryCnt = (int)value[8],
                _totalAttackDamage = (long)value[9],
                _lhsTroops = []
            };
            JArray jArray = (JArray)value[10];
            for (int i = 0; i < jArray.Count; i++)
            {
                result._lhsTroops.Add((Troop)jArray[i]);
            }
            result._rhsTroops = [];
            JArray jArray2 = (JArray)value[11];
            for (int j = 0; j < jArray2.Count; j++)
            {
                result._rhsTroops.Add((Troop)jArray2[j]);
            }
            return result;
        }
    }
}