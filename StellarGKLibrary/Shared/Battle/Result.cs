using StellarGKLibrary.Enums;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StellarGKLibrary.Shared.Battle
{

	[JsonObject(MemberSerialization.OptIn)]
	public class Result
	{
		internal Result()
		{
		}
		public string checksum
		{
			get
			{
				return _checksum;
			}
		}
		public bool isTimeOut
		{
			get
			{
				return _isTimeOut;
			}
		}
		public int winSide
		{
			get
			{
				return _winSide;
			}
		}
		public int clearRank
		{
			get
			{
				return _clearRank;
			}
		}
		public int gold
		{
			get
			{
				return _gold;
			}
		}
		public int armyDestoryCnt
		{
			get
			{
				return _armyDestoryCnt;
			}
		}
		public int armyCmdDestoryCnt
		{
			get
			{
				return _armyCmdDestoryCnt;
			}
		}
		public int navyDestoryCnt
		{
			get
			{
				return _navyDestoryCnt;
			}
		}
		public int navyCmdDestoryCnt
		{
			get
			{
				return _navyCmdDestoryCnt;
			}
		}
		public long totalAttackDamage
		{
			get
			{
				return _totalAttackDamage;
			}
		}
		public IList<Troop> lhsTroops
		{
			get
			{
				return _lhsTroops.AsReadOnly();
			}
		}
		public IList<Troop> rhsTroops
		{
			get
			{
				return _rhsTroops.AsReadOnly();
			}
		}
		public Troop victoryTroop
		{
			get
			{
				if (_winSide < 0)
				{
					foreach (Troop troop in _lhsTroops)
					{
						if (!troop.isAnnihilated)
						{
							return troop;
						}
					}
				}
				if (_winSide > 0)
				{
					foreach (Troop troop2 in _rhsTroops)
					{
						if (!troop2.isAnnihilated)
						{
							return troop2;
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
				foreach (Troop troop in _lhsTroops)
				{
					if (troop.isAnnihilated)
					{
						return false;
					}
				}
				return true;
			}
		}
		public bool IsWin
		{
			get
			{
				return _winSide < 0;
			}
		}

		public static explicit operator JToken(Result value)
		{
            JArray jarray = new()
            {
                value._checksum,
                value._isTimeOut,
                value._winSide,
                value._gold,
                value._clearRank,
                value._armyDestoryCnt,
                value._armyCmdDestoryCnt,
                value._navyDestoryCnt,
                value._navyCmdDestoryCnt,
                value._totalAttackDamage
            };
            JArray jarray2 = new JArray();
			for (int i = 0; i < value._lhsTroops.Count; i++)
			{
				jarray2.Add((JToken)value._lhsTroops[i]);
			}
			jarray.Add(jarray2);
			JArray jarray3 = new JArray();
			for (int j = 0; j < value._rhsTroops.Count; j++)
			{
				jarray3.Add((JToken)value._rhsTroops[j]);
			}
			jarray.Add(jarray3);
			return jarray;
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
                _lhsTroops = new List<Troop>()
            };
            JArray jarray = (JArray)value[10];
			for (int i = 0; i < jarray.Count; i++)
			{
				result._lhsTroops.Add((Troop)jarray[i]);
			}
			result._rhsTroops = new List<Troop>();
			JArray jarray2 = (JArray)value[11];
			for (int j = 0; j < jarray2.Count; j++)
			{
				result._rhsTroops.Add((Troop)jarray2[j]);
			}
			return result;
		}

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
	}
}
