using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BattleSimulator.Battle
{
	[JsonObject(MemberSerialization.OptIn)]
	public class InitState
	{
		internal InitState()
		{
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

		public List<GuildSkillState> guildSkills
		{
			get
			{
				return _guildSkills;
			}
		}

		public List<string> battleItemDrks
		{
			get
			{
				return _battleItemDrks;
			}
		}

		public int randomSeed
		{
			get
			{
				return _randomSeed;
			}
		}

		public EBattleType battleType
		{
			get
			{
				return (EBattleType)_battleType;
			}
		}

		public string stageID
		{
			get
			{
				return _stageId;
			}
		}

		public RaidData raidData
		{
			get
			{
				return _raidData;
			}
		}

		public DualData dualData
		{
			get
			{
				return _dualData;
			}
		}

		public long rhsTroopsHealth
		{
			get
			{
				return _rhsTroopsHealth;
			}
		}

		public long rhsTroopsMaxHealth
		{
			get
			{
				return _rhsTroopsMaxHealth;
			}
		}

		public WaveBattleData waveBattleData
		{
			get
			{
				return _waveBattleData;
			}
		}

		public static InitState Create(EBattleType battleType, List<Troop> lhsTroops, List<Troop> rhsTroops, List<string> battleItemDrks, int randomSeed)
		{
			string text = "must not be empty.";
			if (lhsTroops == null || lhsTroops.Count == 0)
			{
				throw new ArgumentException("lhsTroops " + text);
			}
			if (rhsTroops == null || rhsTroops.Count == 0)
			{
				throw new ArgumentException("rhsTroops " + text);
			}
			return new InitState
			{
				_battleType = (int)battleType,
				_lhsTroops = lhsTroops,
				_rhsTroops = rhsTroops,
				_rhsTroopsHealth = 0L,
				_rhsTroopsMaxHealth = 0L,
				_randomSeed = randomSeed,
				_battleItemDrks = battleItemDrks,
				_stageId = string.Empty
			};
		}

		public static InitState Copy(InitState src)
		{
			if (src == null)
			{
				throw new ArgumentNullException("src");
			}
            InitState initState = new InitState
            {
                _battleType = src._battleType,
                _lhsTroops = new List<Troop>()
            };
            foreach (Troop troop in src._lhsTroops)
			{
				initState._lhsTroops.Add(Troop.Copy(troop));
			}
			initState._rhsTroops = new List<Troop>();
			foreach (Troop troop2 in src._rhsTroops)
			{
				initState._rhsTroops.Add(Troop.Copy(troop2));
			}
			if (src._battleItemDrks != null)
			{
				initState._battleItemDrks = new List<string>();
				for (int i = 0; i < src._battleItemDrks.Count; i++)
				{
					initState._battleItemDrks.Add(src._battleItemDrks[i]);
				}
			}
			if (src._guildSkills != null)
			{
				initState._guildSkills = new List<GuildSkillState>();
				for (int j = 0; j < src._guildSkills.Count; j++)
				{
					initState._guildSkills.Add(GuildSkillState.Copy(src._guildSkills[j]));
				}
			}
			if (src._groupBuffs != null)
			{
				initState._groupBuffs = new List<string>();
				for (int k = 0; k < src._groupBuffs.Count; k++)
				{
					initState._groupBuffs.Add(src._groupBuffs[k]);
				}
			}
			initState._stageId = src._stageId;
			initState._raidData = RaidData.Copy(src.raidData);
			initState._dualData = DualData.Copy(src.dualData);
			initState._waveBattleData = WaveBattleData.Copy(src.waveBattleData);
			initState._randomSeed = src._randomSeed;
			initState._rhsTroopsHealth = src._rhsTroopsHealth;
			initState._rhsTroopsMaxHealth = src._rhsTroopsMaxHealth;
			return initState;
		}

		public static explicit operator JToken(InitState value)
		{
            JArray jarray = new()
            {
                value._battleType,
                value._stageId,
                value._randomSeed
            };
            JArray jarray2 = new();
			for (int i = 0; i < value._lhsTroops.Count; i++)
			{
				jarray2.Add((JToken)value._lhsTroops[i]);
			}
			jarray.Add(jarray2);
			JArray jarray3 = new();
			for (int j = 0; j < value._rhsTroops.Count; j++)
			{
				jarray3.Add((JToken)value._rhsTroops[j]);
			}
			jarray.Add(jarray3);
			if (value._battleType == 5)
			{
				jarray.Add((JToken)value._raidData);
			}
			else if (value._battleType == 6 || value._battleType == 12 || value._battleType == 17 || value._battleType == 13)
			{
				jarray.Add((JToken)value._dualData);
			}
			else if (value._battleType == 10)
			{
				jarray.Add((JToken)value._waveBattleData);
			}
			else
			{
				jarray.Add(string.Empty);
			}
			if (value._guildSkills != null)
			{
				JArray jarray4 = new();
				for (int k = 0; k < value._guildSkills.Count; k++)
				{
					jarray4.Add((JToken)value._guildSkills[k]);
				}
				jarray.Add(jarray4);
			}
			else
			{
				jarray.Add(string.Empty);
			}
			if (value._groupBuffs != null)
			{
				JArray jarray5 = new();
				for (int l = 0; l < value._groupBuffs.Count; l++)
				{
					jarray5.Add(value._groupBuffs[l]);
				}
				jarray.Add(jarray5);
			}
			else
			{
				jarray.Add(string.Empty);
			}
			return jarray;
		}

		public static explicit operator InitState(JToken value)
		{
            InitState initState = new()
            {
                _battleType = (int)value[0],
                _stageId = (string)value[1],
                _randomSeed = (int)value[2],
                _lhsTroops = new List<Troop>()
            };
            JArray jarray = (JArray)value[3];
			for (int i = 0; i < jarray.Count; i++)
			{
				initState._lhsTroops.Add((Troop)jarray[i]);
			}
			initState._rhsTroops = new List<Troop>();
			JArray jarray2 = (JArray)value[4];
			for (int j = 0; j < jarray2.Count; j++)
			{
				initState._rhsTroops.Add((Troop)jarray2[j]);
			}
			if (initState._battleType == 5)
			{
				initState._raidData = (RaidData)value[5];
			}
			else if (initState._battleType == 6 || initState._battleType == 12 || initState._battleType == 17 || initState._battleType == 13)
			{
				initState._dualData = (DualData)value[5];
			}
			else if (initState._battleType == 10)
			{
				initState._waveBattleData = (WaveBattleData)value[5];
			}
			if (value[6].Type == JTokenType.Array)
			{
				JArray jarray3 = (JArray)value[6];
				if (jarray3.Count > 0)
				{
					initState._guildSkills = new List<GuildSkillState>();
					for (int k = 0; k < jarray3.Count; k++)
					{
						initState._guildSkills.Add((GuildSkillState)jarray3[k]);
					}
				}
			}
			if (value[7].Type == JTokenType.Array)
			{
				JArray jarray4 = (JArray)value[7];
				if (jarray4.Count > 0)
				{
					initState._groupBuffs = new List<string>();
					for (int l = 0; l < jarray4.Count; l++)
					{
						initState._groupBuffs.Add((string)jarray4[l]);
					}
				}
			}
			return initState;
		}

		public static bool IsSame(InitState f1, InitState f2)
		{
			if (f1 == f2)
			{
				return true;
			}
			if (f1 == null || f2 == null)
			{
				return false;
			}
			if (f1.randomSeed != f2.randomSeed)
			{
				return false;
			}
			if (f1.battleItemDrks.Count != f2.battleItemDrks.Count)
			{
				return false;
			}
			if (f1.lhsTroops.Count != f2.lhsTroops.Count)
			{
				return false;
			}
			if (f1.rhsTroops.Count != f2.rhsTroops.Count)
			{
				return false;
			}
			for (int i = 0; i < f1.battleItemDrks.Count; i++)
			{
				if (!string.Equals(f1.battleItemDrks[i], f2.battleItemDrks[i]))
				{
					return false;
				}
			}
			for (int j = 0; j < f1.lhsTroops.Count; j++)
			{
				if (!Troop.IsSame(f1.lhsTroops[j], f2.lhsTroops[j]))
				{
					return false;
				}
			}
			for (int k = 0; k < f1.rhsTroops.Count; k++)
			{
				if (!Troop.IsSame(f1.rhsTroops[k], f2.rhsTroops[k]))
				{
					return false;
				}
			}
			return true;
		}

		[JsonProperty("type")]
		internal int _battleType;

		[JsonProperty("stgn")]
		internal string _stageId;

		[JsonProperty("rdsd")]
		internal int _randomSeed;

		[JsonProperty("ltrp")]
		internal List<Troop> _lhsTroops;

		[JsonProperty("rtrp")]
		internal List<Troop> _rhsTroops;

		[JsonIgnore]
		internal long _rhsTroopsHealth;

		[JsonIgnore]
		internal long _rhsTroopsMaxHealth;

		[JsonIgnore]
		internal int _lhsUnitCount;

		[JsonIgnore]
		internal int _lhsAttackerCount;

		[JsonIgnore]
		internal int _lhsDefenderCount;

		[JsonIgnore]
		internal int _lhsSupporterCount;

		[JsonIgnore]
		internal int _lhsInitGrade2Count;

		[JsonIgnore]
		internal int _lhsInitGrade3Count;

		[JsonIgnore]
		internal int _lhsInitGrade4Count;

		[JsonIgnore]
		internal int _lhsInitGrade5Count;

		[JsonProperty("raid", NullValueHandling = NullValueHandling.Ignore)]
		internal RaidData _raidData;

		[JsonProperty("dual", NullValueHandling = NullValueHandling.Ignore)]
		internal DualData _dualData;

		[JsonProperty("wbttl", NullValueHandling = NullValueHandling.Ignore)]
		internal WaveBattleData _waveBattleData;

		[JsonProperty("bitm", NullValueHandling = NullValueHandling.Ignore)]
		internal List<string> _battleItemDrks;

		[JsonProperty("gskl", NullValueHandling = NullValueHandling.Ignore)]
		internal List<GuildSkillState> _guildSkills;

		[JsonProperty("grp")]
		internal List<string> _groupBuffs;
	}
}
